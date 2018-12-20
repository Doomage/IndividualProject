using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class SuperAdmin : AbstractUser
    {        
        public SuperAdmin()
        {   
            userlist = userenum.superadmin;
        }

        public void CreateAccount(string name, string Psw , userenum userlist = userenum.usera )
        {
            var dbcreate = new DatabaseConnection();
            switch (userlist)
            {
                case userenum.admin:                   
                    dbcreate.AddAccount(name, Psw ,4 );
                    break;
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
            bdremove.RemoveAccount(Console.ReadLine());
        }
        
        public void ViewUsersTable()
        {
            var bdview = new DatabaseConnection();
            bdview.SelectAccountTable();
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
