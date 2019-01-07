using System;

namespace IndividualProject
{
    class PrintAffected
    {

        public static void PrintAffectedRows(int affected)
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{affected} Affected rows");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press enter to continue");
            Console.ResetColor();
            Console.ReadKey();
        }


    }
}
