using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class SuperAdmin : AbstractUser
    {
        static UserC userc;
        static UserA usera;
        static UserB userb;
        static Admin admin;

        public SuperAdmin(string name)
        {
            Name = name;
        }
        public static void Creation()
        {
            Console.WriteLine("What user u want to create?");
            Console.WriteLine("Choose between UserA =1  , UserB =2 , UserC =3 , Admin=4");
            switch (int.Parse(Console.ReadLine()))
            {
                default:
                case 1:
                    {
                        CreateUserA();
                        break;
                    }
                case 2:
                    {
                        CreateUserB();
                        break;
                    }
                case 3:
                    {
                        CreateUserC();
                        break;
                    }
                case 4:
                    {
                        CreateAdmin();
                        break;
                    }

            }
        }
        private static void CreateUserA()
        {
            
            Console.WriteLine("Give me your Username");
            string name = Console.ReadLine();
            Console.WriteLine("Give me your Password");
            string psw = Console.ReadLine();

            var login = new Login(name,psw);
            
        }
        private static void CreateUserB()
        {
            Console.WriteLine("Give me your Username");
            string name = Console.ReadLine();
            Console.WriteLine("Give me your Password");
            string psw = Console.ReadLine();

            var login = new Login(name, psw);
            
            
        }
        private static void CreateUserC()
        {
            Console.WriteLine("Give me your Username");
            string name = Console.ReadLine();
            Console.WriteLine("Give me your Password");
            string psw = Console.ReadLine();

            var login = new Login(name, psw);
            
            
        }
        private static void CreateAdmin()
        {
            Console.WriteLine("Give me your Username");
            string name = Console.ReadLine();
            Console.WriteLine("Give me your Password");
            string psw = Console.ReadLine();

            var login = new Login(name, psw);
            
        }




    }
}
