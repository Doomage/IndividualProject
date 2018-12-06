using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IndividualProject
{

    class Program
    {

        static private Login auth = new Login();

        static void Main(string[] args)
        { 
            Console.WriteLine("Enter username : ");
            var username = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            var password = Console.ReadLine();

            var isvalid = auth.ValidateCredentials(username, password);
            if (isvalid == true)
            {
                Console.WriteLine("u are authenticated! ");
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
            //Console.WriteLine("Your are{0} authenticated!", isvalid ? string.Empty : " NOT");
            //Console.ReadLine();

            
            //superadmin.Creation();


        }
    }
}
