using System;
using System.Collections.Generic;

namespace IndividualProject
{
    class User : AbstractUser
    {


        public User()
        {
            UserList = UserEnum.user;
        }

        public virtual int UserMenu()
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
            int answer;  
            while(!int.TryParse(Console.ReadLine(),out answer))
            {
                Console.WriteLine("You have to Choose a number");
            }
            while (answer < 0 || answer > 2)
            {
                Console.WriteLine("You have to Choose between 0 and 2");
                answer = int.Parse(Console.ReadLine());
            }
            return answer;
        }

        public void SendMessage(string name)
        {
            var db = new DatabaseConnection();
            Console.Clear();
            List<Accounts> list = db.SelectAccountTable();
            Console.WriteLine("------Users u can send message-----");

            foreach (var x in list)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"{x.Username}");
                Console.ResetColor();
                Console.Write(" ");
            }
            Console.Write("\nType receiver name : ");
            string ReceiverName = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            Console.Write("Type the message :");
            var Message = Console.ReadLine();
            db.AddMessage(name, ReceiverName, Message);
            TransactedDataFile.TransactedDataSent(ReceiverName, Message, name, DateTime.Now);
        }

        public void ViewMessages(string name)
        {
            var db = new DatabaseConnection();
            var list = db.ViewMessagesByName(name);
            list.Sort((x, y) => string.Compare(Convert.ToString(x.TimeSent), Convert.ToString(y.TimeSent)));
            Console.Clear();
            foreach (var x in list)
            {
                Console.WriteLine($"{x.TimeSent} - {x.SenderName} send to {x.ReceiverName} : {x.Message}");
            }
            if (list.Count == 0)
                Console.WriteLine("You have no messages");
            {
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nPress enter to continue");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
