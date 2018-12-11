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

            Console.WriteLine("give me the username");
            string name = Console.ReadLine();

            Console.WriteLine("give me your password");
            string psw = Console.ReadLine();

            DatabaseConnection.Validate(name, psw);

            ////an uparxei to validate pes oti exeis kanei login
            //if (Login.validatecredentials(name, psw) == true)
            //{
            //    console.writeline("you have login");
            //    console.readline();
            //}
            //else //zita new
            //{
            //    console.writeline("you need to create an account.");
            //    superadmin.creation();

            //}
            //DatabaseConnection.Validate("admin");
            Console.ReadKey();
            



        }
    }
}
