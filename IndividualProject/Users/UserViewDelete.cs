using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProject
{
    class UserViewDelete : UserViewEdit
    {

        public UserViewDelete() : base()
        {
            Role = UserRole.Uservieweditdelete;
        }

        public override int UserMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------UserViewEditDelete Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1.Send a Message");
            Console.WriteLine("2.View your Messages");
            Console.WriteLine("3.View transacted message between 2 users");
            Console.WriteLine("4.Edit messages between 2 users");
            Console.WriteLine("5.Delete a message");
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n0.Log Out");
            Console.ResetColor();
            int answer;
            while (!int.TryParse(Console.ReadLine(), out answer))
            {
                Console.WriteLine("You have to Choose a number");
            }
            while (answer < 0 || answer > 5)
            {
                Console.WriteLine("You have to Choose between 0 and 5");
                answer = int.Parse(Console.ReadLine());
            }
            return answer;
        }

        public void DeleteMessages(string name)
        {
            var db = new DatabaseConnection();
            Console.Clear();
            var MessageForFile = string.Empty;
            Console.Write("Type the User Name you want to delete his messages : ");
            var sender = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            Console.WriteLine("\n");

            var messages = GetMessageList(db, sender);

            foreach (var item in messages)
            {
                Console.WriteLine(item.Description);
            }        
            Console.Write("\nWrite the Message id u want to delete or press enter to go back: ");
            var messageid = int.Parse(Console.ReadLine());
            bool checkmesssageid = true;
            do
            {
                if (messages.Any(msg => msg.Id == messageid))
                {
                    MessageForFile = db.SelectMessageByID(messageid);
                    db.DeleteMessagesById(messageid);
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
            var file = new TransactedDataFile();
            file.DeleteMessageFile(sender, MessageForFile, name, DateTime.Now);
        }
    }
}
