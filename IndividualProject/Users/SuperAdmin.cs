using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class SuperAdmin : User
    {        
        public SuperAdmin()
        {   
            userlist = userenum.superadmin;
        }

        public string SuperAdminMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------Superadmin Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1. Create new User");
            Console.WriteLine("2. Update User Access");
            Console.WriteLine("3. View Users and each Access");
            Console.WriteLine("4. Delete a User");
            Console.WriteLine("5. Update User password");
            Console.WriteLine("6. Send a Message");
            Console.WriteLine("7. View Your Messages");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("0.Exit");
            Console.ResetColor();
            return Console.ReadLine();
        }
        public void CreateAccount(string name, string Psw , userenum userlist = userenum.usera )
        {
            var dbcreate = new DatabaseConnection();
            switch (userlist)
            {
                case userenum.userc:
                default:                   
                    dbcreate.AddAccount(name, Psw, 3 );
                    break;
                case userenum.userb:                   
                    dbcreate.AddAccount(name, Psw, 2 );
                    break;
                case userenum.usera:                    
                    dbcreate.AddAccount(name, Psw, 1);
                    break;
            }
        }
        
        public static void RemoveAccount()
        {
            var bdremove = new DatabaseConnection();
            Console.Clear();
            Console.Write("Write the username u want to ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" delete : ");
            Console.ResetColor();

            bdremove.RemoveAccount(Login.CheckingUsernameForChangeAccess(Console.ReadLine()));
        }
        
        public void ViewUsersTable()
        {
            var bdview = new DatabaseConnection();
           var list =  bdview.SelectAccountTable();
            foreach(var x in list)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Username : ");
                Console.ResetColor();
                Console.Write(x.Username);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(" Access : ");
                Console.ResetColor();
                if (x.Userlevel == 1)
                {
                    Console.Write("SimpleUser" + "\n");
                }
                else if (x.Userlevel ==2)
                {
                    Console.Write("UserView" + "\n");
                }
                else if (x.Userlevel == 3)
                {
                    Console.Write("UserViewEditDelete" + "\n");
                }
                else if (x.Userlevel == 4)
                {
                    Console.Write("UserViewEditDelete" + "\n");
                }
                else
                {
                    Console.Write("Admin" + "\n");
                }
            }
            Console.ReadKey();
        }

        public void ChangeUserAccess(string name,int userlevel)
        {
            var bd = new DatabaseConnection();
            bd.AssignRoleBySuperAdmin(name, userlevel);
        }

        public void ChangeUserPassword(string name, string psw)

        {
            var db = new DatabaseConnection();
            db.ChangeUserPassword(name, psw);

        }
    }
}
