using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class Menu
    {
        DatabaseConnection db = new DatabaseConnection();
        

        public static void MenuSuperAdmin(string name)
        {
            var SAdmin = new SuperAdmin();
            bool check = true;
            do
            {
                switch (SAdmin.SuperAdminMenu())
                {
                    case "1":
                        try
                        {
                            SAdmin.CreateAccount(Login.CheckingUsername(), Login.CheckingPassword());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "2":
                        int UserAccess;
                        try
                        {
                            Console.Clear();
                            Console.Write("Give Username : ");
                            string Name = Console.ReadLine();
                            var username = Login.CheckingUsernameForChangeAccess(Name);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"User {username} has level { DatabaseConnection.SelectUserlevelByUsername(username)} Access ");
                            Console.ResetColor();
                            Console.WriteLine("Give Access level u want to grand");
                            Console.WriteLine("1.User");
                            Console.WriteLine("2.UserView");
                            Console.WriteLine("3.UserViewEdit");
                            Console.WriteLine("4.UserViewEditDelete");
                            do
                            {
                                Console.WriteLine("U have to pick between 1 and 4");
                                UserAccess = int.Parse(Console.ReadLine());
                            } while (UserAccess < 1 || UserAccess > 4);
                            SAdmin.ChangeUserAccess(username, UserAccess);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "3":
                        try
                        {
                            Console.Clear();
                            SAdmin.ViewUsersTable();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        try
                        {
                            SuperAdmin.RemoveAccount();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        try
                        {
                            Console.Clear();
                            Console.Write("Give Username you want to change the psw : ");
                            var username = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
                            var psw = Login.CheckingPassword();
                            SAdmin.ChangeUserPassword(username, psw);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "6":
                        try
                        {
                            SAdmin.SendMessage(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "7":
                        try
                        {
                            SAdmin.ViewMessages(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "0":
                    default:
                        check = false;
                        break;
                }
            } while (check == true);
        }
        
        public static void MenuUserView(string name)
        {
            var userView = new UserView();

            bool check = true;
            do
            {
                switch (userView.UserMenu())
                {
                    case "1":
                        try
                        {
                            userView.SendMessage(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        try
                        {
                            userView.ViewMessages(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        try
                        {
                            userView.ViewUsersMessages();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "0":
                    default:
                        check = false;
                        break;
                }
            } while (check == true);

        }

        
        public static void MenuUserViewEdit(string name)
        {
            var UserViewEdit = new UserViewEdit();
            bool check = true;
            do
            {
                switch (UserViewEdit.UserMenu())
                {
                    case "1":
                        try
                        {
                            UserViewEdit.SendMessage(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        try
                        {
                            UserViewEdit.ViewMessages(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        try
                        {
                            UserViewEdit.ViewUsersMessages();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        try
                        {
                            UserViewEdit.EditMessage(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "0":
                    default:
                        check = false;
                        break;
                }
            } while (check == true);
        }

        
        public static void MenuUserViewEditDelete(string name)
        {
            var Uved = new UserViewDelete();
            bool check = true;
            do
            {
                switch (Uved.UserMenu())
                {
                    case "1":
                        try
                        {
                            Uved.SendMessage(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        try
                        {
                            Uved.ViewMessages(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        try
                        {
                            Uved.ViewUsersMessages();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        try
                        {
                            Uved.EditMessage(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "5":
                        try
                        {
                            Uved.DeleteMessages(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "0":
                    default:
                        check = false;
                        break;
                }
            } while (check == true);

        }


        public static void MenuUser(string name)
        {
            var User = new User();
            bool check = true;
            do
            {
                switch (User.UserMenu())
                {
                    case "1":
                        try
                        {
                            User.SendMessage(name);                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        try
                        {
                            User.ViewMessages(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "0":
                    default:
                        check = false;
                        break;
                }
            } while (check == true);
        }
    }
}
