using System;

namespace IndividualProject
{
    class UserView:User
    {
        
        public UserView()
        {            
            userlist = userenum.userview;
        }
        public override string UserMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------UserView Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1.Send a Message");
            Console.WriteLine("2.View your Messages");
            Console.WriteLine("3.View transacted message between 2 users");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n0.Log Out");
            Console.ResetColor();
            return Console.ReadLine();
        }
        
        public void ViewUsersMessages()
        {
            Console.Clear();
            Console.Write("Type the 1st User Name : ");
            string FirstName = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            Console.Write("Type the 2nd User Name : ");
            string SecondName = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            Console.Clear();

            var db = new DatabaseConnection();
            var list = db.ReadMessages(FirstName,SecondName);
            list.Sort((x, y) => string.Compare(Convert.ToString(x.TimeSent), Convert.ToString(y.TimeSent)));
            foreach (var x in list)
            {
                Console.WriteLine($"{x.TimeSent} : {x.SenderName} send to {x.ReceiverName} : {x.Message}");
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nPress enter to continue");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
