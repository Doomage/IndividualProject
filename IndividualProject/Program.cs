using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IndividualProject
{

    class Program
    {
        static void Main(string[] args)
        {

            SuperAdmin Sadmin = new SuperAdmin();
            Console.Write("Username : ");
            string name = Console.ReadLine();
            if (DatabaseConnection.ValidateAccount(name, Login.CheckingPassword()) == true)
            {
                Console.WriteLine("You login");
            }
            else
            {
                Console.WriteLine("You have to create an Account to log in");
                Console.WriteLine("Do u want to create an account? y/n");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        Sadmin.Addaccount(Login.CheckingUsername(), Login.CheckingPassword());
                        break;
                    case "n":
                    default:
                        Console.WriteLine("Bye Bye");
                        break;
                }
            }
            Console.ReadKey();
        }        
    }
}
