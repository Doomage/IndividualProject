using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class SuperAdmin : AbstractUser
    {
        UserC userc;
        UserA usera;
        UserB userb;
        Admin admin;
        static SuperAdmin superadmin;

        private SuperAdmin(string name)
        {
            Name = name;
        }
        public static SuperAdmin CreateSuperAdmin()
        {
            if(superadmin == null)
            {
                Console.WriteLine("Give me your Username");
                string name = Console.ReadLine();
                superadmin = new SuperAdmin(name);
            }
            return superadmin;
        }
        public void CreateUserA()
        {
            Console.WriteLine("Give me your Username");
            string name = Console.ReadLine();
            usera = new UserA(name);
        }
        public void CreateUserB()
        {
            Console.WriteLine("Give me your Username");
            string name = Console.ReadLine();
            userb = new UserB(name);
        }
        public void CreateUserC()
        {
            Console.WriteLine("Give me your Username");
            string name = Console.ReadLine();
            userc = new UserC(name);
        }
        public void CreateAdmin()
        {
            Console.WriteLine("Give me your Username");
            string name = Console.ReadLine();
            admin = new Admin(name);
        }
        public void dafawfaw()
        {
            usera.ViewDatabase();
            userb.ViewDatabase();
            userb.WriteDatabase();
            userc.DeleteDatabaseColumn();
            userc.ViewDatabase();
            userc.WriteDatabase();
            
        }




    }
}
