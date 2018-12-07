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
                Console.WriteLine("Give me the username");
                string name = Console.ReadLine();
                Console.WriteLine("Give me your Password");
                string psw = Console.ReadLine();
                if (Login.ValidateCredentials(name,psw)==true)
                {
                    Console.WriteLine("You have login");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You need to create an account.");
                    SuperAdmin.Creation();

                }

            } while (true);

        }
    }
}
