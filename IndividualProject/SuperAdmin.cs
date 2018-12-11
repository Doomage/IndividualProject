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
            userlist = userenum.superadmin;
        }

        public void Addaccount(string name, string Psw , userenum userlist = userenum.userc )
        {
            switch (userlist)
            {
                case userenum.admin:
                    var bdcreate = new DatabaseConnection();
                    bdcreate.AddAccount(name, Psw ,4 );
                    break;
                case userenum.userc:
                default:
                    var dabase = new DatabaseConnection();
                    dabase.AddAccount(name, Psw, 3 );
                    break;
                case userenum.userb:
                    var database = new DatabaseConnection();
                    database.AddAccount(name, Psw, 2 );
                    break;
                case userenum.usera:
                    var bddcreate = new DatabaseConnection();
                    bddcreate.AddAccount(name, Psw, 1);
                    break;
            }
        }
        public static void Authentication()
        {
            Console.WriteLine("Give me the username u want to have to create an account");
            string name = Console.ReadLine();

            if(name == string.Empty || name == null)
            {
                do
                {
                    Console.WriteLine("u need to have a stronger psw");
                    name = Console.ReadLine();
                } while (name == string.Empty || name == null);
            }


            Console.WriteLine("Give me your Password u want to have to login an account");
            string psw = Console.ReadLine();
            if (psw == string.Empty || psw == null)
            {
                do
                {
                    Console.WriteLine("u need to have a stronger psw");
                    psw = Console.ReadLine();
                } while (psw == string.Empty || psw == null);
            }

            //var login = new Login(name, psw);
        }
        //public static void AddAccount()
        //{
        //    var bdcreate = new DatabaseConnection();
        //    bdcreate.AddAccount("name", "name", 2);
        //}
        public static void RemoveAccount()
        {
            var bdremove = new DatabaseConnection();
            bdremove.RemoveAccount("name");
        }

    }
}
