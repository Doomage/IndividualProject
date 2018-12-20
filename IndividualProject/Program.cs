using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IndividualProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Project Chat";
            SuperAdmin Sadmin = new SuperAdmin();
            var check = true;
            Login.ApplicationWelcomeMenu();
            do
            {
                Console.Clear();               
                Console.Write("Username : ");
                string name = Console.ReadLine();
                var psw = Login.CheckingPassword();
                if (DatabaseConnection.ValidateAccount(name, psw))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You login");
                    Console.ReadKey();
                    Console.ResetColor();
                    var UserAccess = DatabaseConnection.GetUserAccess(name, psw);
                    switch (UserAccess)
                    {
                        case 4:
                            {
                                Menu.MenuSuperAdmin();
                            }
                            break;
                        case 3:
                            {
                                Menu.MenuUserC();
                            }
                            break;
                        case 2:
                            {
                                Menu.MenuUserB();
                            }
                            break;
                        case 1:
                        default:
                            {
                                Menu.MenuUserA();
                            }
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to create an Account to log in");
                    Console.ResetColor();
                    Console.WriteLine("Do u want to create an account? y/n");
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "y":
                            Sadmin.CreateAccount(Login.CheckingUsername(), Login.CheckingPassword());
                            break;
                        case "n":
                        default:
                            Console.WriteLine("Bye Bye");
                            check = false;
                            break;
                    }
                }
                Console.ReadKey();
            } while (check == true);
        }
    }
}
