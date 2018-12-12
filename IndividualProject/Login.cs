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

        public static void CheckingUsername(string name)
        {
            while(DatabaseConnection.ValidateUsername(name) == true)
            {
                Console.WriteLine("You have to choose an other username");
                name = Console.ReadLine();
            }
                
        }
        public static void CheckingPassword(string psw)
        {
            while (psw.Length == 0)
            {  
                    Console.WriteLine("You cant have a passworld with 0 letters");
                    Console.WriteLine("Give me your password");
                    psw = Console.ReadLine(); 
            }
        }

        
        
    }
}
