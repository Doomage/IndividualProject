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

            Console.WriteLine("give me the username");
            string name = Console.ReadLine();

            Console.WriteLine("give me your password");
            string psw = Console.ReadLine();

            if (DatabaseConnection.Validate(name,psw)== true)
            {
                Console.WriteLine("You login");
            }
            else
            {
                string password;
                Console.WriteLine("You have to create an Account to log in");
                Console.WriteLine("Do u want to create an account? y/n");
                string answer = Console.ReadLine();
                switch (answer)
                {

                    case "y":
                                         
                        Console.WriteLine("Give me Username you want to Create");
                        string Name = Console.ReadLine();
                        Login.CheckingUsername(Name);                           
                        Console.WriteLine("Give me your password");
                        password = Console.ReadLine();
                        if (password.Length == 0)
                        {
                            do
                            {
                                Console.WriteLine("You cant have a passworld with 0 letters");
                                Console.WriteLine("Give me your password");
                                password = Console.ReadLine();

                            } while (password.Length == 0);
                        }
                        Sadmin.Addaccount(Name, password);                           
                        break;
                    case "n":
                    default:
                        Console.WriteLine("Bye bye");
                        break;

                    




                }
                
            }

            
            Console.ReadKey();
            



        }
    }
}
