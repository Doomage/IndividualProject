using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class UserView:User
    {
        
        public UserView()
        {            
            userlist = userenum.usera;
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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("0.Log Out");
            Console.ResetColor();
            return Console.ReadLine();
        }
        
        public void ViewUserMessages()
        {
            Console.Clear();
            Console.Write("Type the 1st User Name : ");
            string FirstName = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            Console.Write("Type the 2nd User Name : ");
            string SecondName = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            Console.Clear();
            var list = ViewMessage(FirstName, SecondName);
            var list2 = ViewMessage(SecondName, FirstName);
            foreach (var element in list2)
            {
                list.Add(element);
            }
            list.Sort((x, y) => string.Compare(Convert.ToString(x.TimeSent), Convert.ToString(y.TimeSent)));
            foreach (var x in list)
            {
                Console.WriteLine($"Message id {x.MessagesId} = {x.TimeSent} User {x.SenderName} send to User {x.ReceiverName} : {x.Message}");
            }
            Console.ReadKey();
        }
    }
}
