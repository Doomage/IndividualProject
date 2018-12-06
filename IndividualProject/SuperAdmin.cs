using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class SuperAdmin : AbstractUser
    {        
        public SuperAdmin(string name)
        {
            Name = name;
        }

        public static void Creation()
        {
            Console.WriteLine("Give me the username u want to have to create an account");
            string name = Console.ReadLine();
            Console.WriteLine("Give me your Password u want to have to login an account");
            string psw = Console.ReadLine();

            var login = new Login(name,psw);
        }
        
    }
}
