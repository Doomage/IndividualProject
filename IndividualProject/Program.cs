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
            do
            {
                

                Console.WriteLine("Enter username : ");
                var username = Console.ReadLine();
                Console.WriteLine("Enter password : ");
                var password = Console.ReadLine();
                Login auth = new Login(username,password);

                var isvalid = auth.ValidateCredentials();

                if (isvalid == true)
                {
                    Console.WriteLine("You are authenticated! ");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Do u want to create an account? y/n");
                    var answer = Console.ReadLine();
                    if (answer == "y")
                    {
                        SuperAdmin.Creation();
                    }

                }
            } while (true);

        }
    }
}
