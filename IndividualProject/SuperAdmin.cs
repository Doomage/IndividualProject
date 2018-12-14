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

        public void Addaccount(string name, string Psw , userenum userlist = userenum.userc )
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
            bdremove.RemoveAccount("name");
        }

    }
}
