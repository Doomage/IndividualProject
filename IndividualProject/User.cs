using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class User : AbstractUser
    {


        public User()
        {
            userlist = userenum.user;
        }

        public  string UserMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------User Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1.Send a Message");
            Console.WriteLine("2.View your Messages");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("0.Log Out");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public void SendMessage(string sender,string receiver,string Message)
        {
            var db = new DatabaseConnection();
            db.AddMessage(sender, receiver, Message);
        }
        public List<Messages> ViewMessage(string sender, string receiver)
        {
            var db = new DatabaseConnection();
            return db.ReadMessages(sender, receiver);
        }
    }
}
