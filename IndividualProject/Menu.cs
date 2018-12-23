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
        

        public static void MenuSuperAdmin()
        {
            var SuperAdmin = new SuperAdmin();
            bool check = true;
            do
            {
                switch (SuperAdmin.SuperAdminMenu())
                {
                    case "1":
                        try
                        {
                            SuperAdmin.CreateAccount(Login.CheckingUsername(), Login.CheckingPassword());
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
                            Console.WriteLine("2.UserA");
                            Console.WriteLine("3.UserB");
                            Console.WriteLine("4.UserC");
                            do
                            {
                                Console.WriteLine("U have to pick between 1 and 4");
                                UserAccess = int.Parse(Console.ReadLine());
                            } while (UserAccess < 1 || UserAccess > 4);
                            SuperAdmin.ChangeUserAccess(username, UserAccess);
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
                            SuperAdmin.ViewUsersTable();
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
                            SuperAdmin.ChangeUserPassword(username, psw);
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
                            userView.ViewMessage(name);
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
                            userView.ViewUserMessages();
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

        //TODO
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
                            UserViewEdit.ViewMessage(name);
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
                            UserViewEdit.ViewUserMessages();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        try
                        {
                            UserViewEdit.EditMessage();
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

        //TODO
        public static void MenuUserViewEditDelete(string name)
        {
            var Admin = new UserViewDelete();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------UserC Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1.Add User");
            Console.WriteLine("2.Change User Access");
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
                            User.ViewMessage(name);
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
