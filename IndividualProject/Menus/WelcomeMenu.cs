using System;

namespace IndividualProject
{
    class WelcomeMenu
    {
        public static void ApplicationWelcomeMenu()
        {
            Console.SetWindowSize(110, 20);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(35, 9);
            Console.WriteLine("-----Created by George Lymperopoulos------");
            Console.SetCursorPosition(35, 8);
            Console.WriteLine("---------Welcome to Project Chat----------");
            Console.SetCursorPosition(35, 7);
            Console.WriteLine("------------------------------------------");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void ApplicationWrongUsernameOrPassword()
        {
            Console.Clear();
            Console.SetWindowSize(110, 20);
            Console.BackgroundColor = ConsoleColor.Red;              
            Console.SetCursorPosition(35, 7);
            Console.WriteLine("Wrong Username or Password");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
