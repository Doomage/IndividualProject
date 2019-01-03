using System;


namespace IndividualProject
{
    class Login
    {
        public Login()
        {
        }
        public static void SignUp()
        {           
            var Sadmin = new SuperAdmin();
            Console.Clear();          
            Sadmin.CreateAccount(Login.CheckingUsername(),Login.CheckingPassword());           
        }
        public static string CheckingUsername()
        {
            Console.Clear();
            Console.Write("Type Username you want to Create : ");
            string Name = Console.ReadLine();
            // checking if the username is empty or has spaces!
            while (Name == string.Empty || Name.Contains(" "))
            {               
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You can't have a Username with Spaces");
                Console.ResetColor();
                Console.Write("Type Username again : ");                
                Name = Console.ReadLine();
                Console.Clear();
            }
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
            Console.Write("Give Password : ");
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

