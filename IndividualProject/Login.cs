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
        public static bool SignUp()
        {
            
            var Sadmin = new SuperAdmin();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have to create an Account to log in");
            Console.ResetColor();
            Console.WriteLine("Do u want to create an account? y/n");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "y":
                    Sadmin.CreateAccount(Login.CheckingUsername(), Login.CheckingPassword());
                    return true;
                case "n":
                default:
                    Console.WriteLine("Bye Bye");
                    return false;                    
            }
        }
        public static string CheckingUsername()
        {
            Console.Clear();
            Console.Write("Give me Username you want to Create : ");
            string Name = Console.ReadLine();

            while (DatabaseConnection.ValidateUsername(Name) == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have to choose an other username");
                Console.ResetColor();
                Name = Console.ReadLine();
            }
            return Name;
        }

        public static string CheckingUsernameForChangeAccess(string Name)
        {
            while (DatabaseConnection.ValidateUsername(Name) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("You have to choose an other username : ");
                Console.ResetColor();
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
                    if (key.Key == ConsoleKey.Backspace && psw.Length != 0)
                    {
                        psw = psw.Substring(1, psw.Length - 1);
                        Console.Write("\b");
                        Console.Write(" ");
                        Console.Write("\b");

                    }
                }
            } while (key.Key != ConsoleKey.Enter || psw.Length == 0);
            Console.WriteLine("\n");
            return psw;
        }

        
    }
}

