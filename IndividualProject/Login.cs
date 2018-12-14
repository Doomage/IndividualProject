using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace IndividualProject
{
    class Login
    {
        public Login()
        {
        }

        public static string CheckingUsername()
        {
            Console.Write("Give me Username you want to Create : ");
            string Name = Console.ReadLine();

            while (DatabaseConnection.ValidateUsername(Name) == true)
            {
                Console.WriteLine("You have to choose an other username");
                Name = Console.ReadLine();
            }
            return Name;
        }

        public static string CheckingPassword()
        {
            Console.Write("Password : ");
            ConsoleKeyInfo key;

            string psw = string.Empty;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    psw += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && psw.Length !=0)
                    {
                        psw = psw.Substring(1, psw.Length - 1);
                        Console.Write("\b");
                        Console.Write(" ");
                        Console.Write("\b");

                    }
                }              
            } while (key.Key != ConsoleKey.Enter || psw.Length==0);
            Console.WriteLine("\n");
            return psw;
        }
    }
}
