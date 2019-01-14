using System;
using System.Collections.Generic;

namespace IndividualProject
{
    class UserViewEdit:UserView 
    {
        
        public UserViewEdit() : base ()
        {           
            UserList = UserEnum.userviewedit;
        }

        public void EditMessage(string name)
        {
            
            Console.Clear();
            Console.Write("Type the User Name you want to edit his messages : ");
            //Using datetime.now to take the time and add it to file!
            DateTime dateTime = DateTime.Now;
            var Sender = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            var db = new DatabaseConnection();
            var list = db.ChooseMessagesBySendername(Sender);
            var list2 = db.ChooseMessagesByReceivername(Sender);
            //kanw add ola ta antikeimena ths list2 sthn list meta ta kanw order 
            foreach(var element in list2)
            {
                list.Add(new Messages()
                {
                    Message = element.Message,
                    MessagesId = element.MessagesId,
                    SenderName = element.SenderName,
                    ReceiverName = element.ReceiverName,
                    TimeSent = element.TimeSent                   
                });
            }
            Console.WriteLine("\n");
            List<int> checkid = new List<int>();
            list.Sort((x, y) => string.Compare(Convert.ToString(x.TimeSent), Convert.ToString(y.TimeSent)));
            foreach (var x in list)
            {
                Console.WriteLine($"Message id {x.MessagesId}, {x.TimeSent} : {x.SenderName} send to {x.ReceiverName} : {x.Message}");
                checkid.Add(x.MessagesId);
            }
            Console.Write("\nWrite the Message id u want to change or press enter to go back: ");
            var messageid = int.Parse(Console.ReadLine());
            bool checkmesssageid = true;
            do
            {       
                    if (checkid.Contains(messageid))
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
            DatabaseConnection.UpdateMessages(message, messageid);
            TransactedDataFile.TransactedDataEdit(Sender, message, name,dateTime);
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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("0.Log Out");
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
    }
}
