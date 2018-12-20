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
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("0.Exit");
                Console.ResetColor();
                switch (Console.ReadLine())
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
                            var username = Login.CheckingUsernameForChangeAccess();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"User {username} has level { DatabaseConnection.SelectUserlevelByUsername(username)} Access ");
                            Console.ResetColor();
                            Console.WriteLine("Give Access level u want to grand");
                            Console.WriteLine("1.UserA");
                            Console.WriteLine("2.UserB");
                            Console.WriteLine("3.UserC");
                            Console.WriteLine("4.Admin");           
                            do
                            {
                                Console.WriteLine("U have to pick between 1 and 4");
                                UserAccess = int.Parse(Console.ReadLine());
                            } while (UserAccess < 1 || UserAccess > 4);
                            SuperAdmin.ChangeUserAccess(username, UserAccess);
                        }
                        catch(Exception e)
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
                        catch(Exception e)
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
                        }
                        break;
                    case "5":
                        try
                        {
                            var username = Login.CheckingUsernameForChangeAccess();
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
        public static void MenuAdmin()
        {
            var Admin = new Admin();
            bool check = true;
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------Admin Menu----------");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("1.Add User");
                Console.WriteLine("2.Change User Access");
                switch (Console.ReadLine())
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "0":
                    default:
                        check = false;
                        break;
                }
            } while (check == true);
        }
        public static void MenuUserA()
        {
            var userA = new UserA();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------UserA Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1.View the transacted data between the users");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("0.Exit");
            Console.ResetColor();

        }
        public static void MenuUserB()
        {
            var userB = new UserB();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------UserB Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1.Add User");
            Console.WriteLine("2.Change User Access");

        }
        public static void MenuUserC()
        {
            var Admin = new UserC();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------UserC Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1.Add User");
            Console.WriteLine("2.Change User Access");
        }





    }
}
