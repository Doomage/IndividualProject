using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProject
{
    class UserViewEdit:UserView 
    {
        
        public UserViewEdit() : base ()
        {           
            Role = UserRole.Userviewedit;
        }

        public override int UserMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------UserViewEdit Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1.Send a Message");
            Console.WriteLine("2.View your Messages");
            Console.WriteLine("3.View transacted message between 2 users");
            Console.WriteLine("4.Edit messages between 2 users");
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n0.Log Out");
            Console.ResetColor();
            int answer;
            while (!int.TryParse(Console.ReadLine(), out answer))
            {
                Console.WriteLine("You have to Choose a number");
            }
            while (answer < 0 || answer > 4)
            {
                Console.WriteLine("You have to Choose between 0 and 4");
                answer = int.Parse(Console.ReadLine());
            }
            return answer;
        }

        protected List<(int Id, string Description)> GetMessageList(DatabaseConnection db, string sender)
        {
            var list = db.ChooseMessagesBySendername(sender);
            list.AddRange(db.ChooseMessagesByReceivername(sender));

            list.Sort((x, y) => x.TimeSent.CompareTo(y.TimeSent));
            return list.Select(x => (Id: x.MessagesId, Description: $"Message id {x.MessagesId}, {x.TimeSent} : {x.SenderName} send to {x.ReceiverName} : {x.Message}")).ToList();
        }

        public void EditMessage(string name)
        {
            var db = new DatabaseConnection();
            Console.Clear();
            Console.Write("Type the User Name you want to edit his messages : ");
            var sender = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            Console.WriteLine("\n");
            
            var messages = GetMessageList(db, sender);

            foreach (var item in messages)
            {
                Console.WriteLine(item.Description);
            }

            Console.Write("\nWrite the Message id u want to change or press enter to go back: ");
            var messageid = int.Parse(Console.ReadLine());
            bool checkmesssageid = true;
            do
            {
                if (messages.Any(msg => msg.Id == messageid))
                {
                    checkmesssageid = false;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Write the correct Message id : ");
                    Console.ResetColor();
                    messageid = int.Parse(Console.ReadLine());
                }
            } while (checkmesssageid == true);
            Console.Write("\nWrite the new message : ");
            var message = Console.ReadLine();
            db.UpdateMessages(message, messageid);
            var file = new TransactedDataFile();
            file.TransactedDataEdit(sender, message, name, DateTime.Now);
        }
    }
}
