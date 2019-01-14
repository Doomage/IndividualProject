using System;

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
                    case 1:
                        try
                        {
                            SAdmin.CreateAccount(Login.CheckingUsername(), Login.CheckingPassword());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 2:
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
                                Console.WriteLine("U have to choose between 1 and 4");
                                UserAccess = int.Parse(Console.ReadLine());
                            } while (UserAccess < 1 || UserAccess > 4);
                            SAdmin.ChangeUserAccess(username, UserAccess);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        try
                        {
                            Console.Clear();
                            SAdmin.ViewUsersTable();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 4:
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
                    case 5:
                        try
                        {
                            Console.Clear();
                            Console.Write("Give Username you want to change the psw : ");
                            var username = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
                            var psw = Login.CheckingPassword();
                            SAdmin.ChangeUserPassword(username, psw);
                        }
                        catch (System.IO.IOException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        catch (OutOfMemoryException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 6:
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
                    case 7:
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
                    case 0:
                    default:
                        Console.WriteLine("\nLogged out");
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
                    case 1:
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
                    case 2:
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
                    case 3:
                        try
                        {
                            userView.ViewUsersMessages();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 0:
                    default:
                        Console.WriteLine("\nLogged out");
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
                    case 1:
                        UserViewEdit.SendMessage(name);
                        break;
                    case 2:
                        UserViewEdit.ViewMessages(name);
                        break;
                    case 3:
                        UserViewEdit.ViewUsersMessages();
                        break;
                    case 4:
                        UserViewEdit.EditMessage(name);
                        break;
                    case 0:
                    default:
                        Console.WriteLine("\nLogged out");
                        check = false;
                        break;
                }
            } while (check == true);
        }
        public static void MenuUserViewEditDelete(string name)
        {
            var UserViewDelete = new UserViewDelete();
            bool check = true;
            do
            {
                switch (UserViewDelete.UserMenu())
                {
                    case 1:
                        try
                        {
                            UserViewDelete.SendMessage(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        try
                        {
                            UserViewDelete.ViewMessages(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        try
                        {
                            UserViewDelete.ViewUsersMessages();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        try
                        {
                            UserViewDelete.EditMessage(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        try
                        {
                            UserViewDelete.DeleteMessages(name);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case 0:
                    default:
                        Console.WriteLine("\nLogged out");
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
                    case 1:
                        User.SendMessage(name);
                        break;
                    case 2:
                        User.ViewMessages(name);
                        break;
                    case 0:
                    default:
                        Console.WriteLine("\nLogged out");
                        check = false;
                        break;
                }
            } while (check == true);
        }
    }
}
