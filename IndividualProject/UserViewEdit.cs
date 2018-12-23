using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class UserViewEdit:UserView 
    {
        
        public UserViewEdit() : base ()
        {           
            userlist = userenum.userb;
        }

        public void EditMessage()
        {
            Console.Clear();
            Console.Write("Type the User Name you want to edit his messages : ");
            var Sender = Login.CheckingUsernameForChangeAccess(Console.ReadLine());

            var list = ChooseMessages(Sender);
            Console.WriteLine("\n");
            List<int> checkid = new List<int>();
            foreach (var x in list)
            {
                Console.WriteLine($"Message id {x.MessagesId} . {x.SenderName} send to {x.ReceiverName} : {x.Message}");
                checkid.Add(x.MessagesId);
            }
            Console.Write("\nWrite the Message id u want to change : ");
            var messageid = int.Parse(Console.ReadLine());
            bool checkmesssageid = true;
            do
            {
                foreach (var s in checkid)
                {
                    if (messageid == s)
                    {
                        checkmesssageid = false;
                        break;
                    }
                    else
                    {
                        Console.Write("\nWrite the Message id u want to change : ");
                        messageid = int.Parse(Console.ReadLine());
                    }
                }
            } while (checkmesssageid == true);
            Console.Write("\nWrite the new message : ");
            var message = Console.ReadLine();
            DatabaseConnection.UpdateMessages(message, messageid);
        }

        public List<Messages> ChooseMessages(string sender)
        {
            var db = new DatabaseConnection();
            return db.ChooseMessages(sender);
        }
        public override string UserMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------User Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1.Send a Message");
            Console.WriteLine("2.View your Messages");
            Console.WriteLine("3.View transacted message between 2 users");
            Console.WriteLine("4.Edit messages between 2 users");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("0.Log Out");
            Console.ResetColor();
            return Console.ReadLine();
        }
    }
}
