
using System;

namespace IndividualProject
{
    class SuperAdmin : UserViewDelete
    {        
        public SuperAdmin()
        {   
            Role = UserRole.Superadmin;
        }
        public void CreateSuperAdmin()
        {
            var db = new DatabaseConnection();
            if(db.ValidateUsername("admin")==false)
            {
                CreateAccount("admin", "admin", UserRole.Superadmin);
            }
        }
        public int SuperAdminMenu()
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
            Console.WriteLine("8. View transacted message between 2 users");
            Console.WriteLine("9. Edit messages between 2 users");
            Console.WriteLine("10. Delete a message");
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n0.Logout");
            Console.ResetColor();
            int answer;
            while (!int.TryParse(Console.ReadLine(), out answer))
            {
                Console.WriteLine("You have to Choose a number");
            }
            while (answer<0 || answer>10)
            {
                Console.WriteLine("You have to Choose between 0 and 10");
                answer = int.Parse(Console.ReadLine());
            }
            return answer;
        }
        public void CreateAccount(string name, string Psw , UserRole userlist = UserRole.User )
        {
            var dbcreate = new DatabaseConnection();
            switch (userlist)
            {
                case UserRole.Uservieweditdelete:                                   
                    dbcreate.AddAccount(name, Psw, 4 );
                    break;
                case UserRole.Userviewedit:                   
                    dbcreate.AddAccount(name, Psw, 3 );
                    break;
                case UserRole.User:                    
                    dbcreate.AddAccount(name, Psw, 1);
                    break;
                case UserRole.Superadmin:
                    dbcreate.AddAccount(name, Psw, 5);
                    break;
                case UserRole.Userview:
                    dbcreate.AddAccount(name, Psw, 2);
                    break;
            }
        }
        
        public  void RemoveAccount()
        {
            var bdremove = new DatabaseConnection();
            Console.Clear();
            Console.Write("Write the username u want to ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" delete : ");
            Console.ResetColor();
            var username = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            bdremove.RemoveAccount(username);
            bdremove.RemoveMessages(username);
            var file = new TransactedDataFile();
            file.DeleteUserFile(username);
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
                Console.ForegroundColor = ConsoleColor.DarkGreen;
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
                    Console.Write("UserViewEdit" + "\n");
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
