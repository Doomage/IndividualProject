using System;

namespace IndividualProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Project Chat";
            SuperAdmin Sadmin = new SuperAdmin();
            var check = true;
            WelcomeMenu.ApplicationWelcomeMenu();
            do
            {
                Console.Clear();
                Console.WriteLine("1.Login\n2.Sign Up");
                try
                {
                    var AnswerDecide = int.Parse(Console.ReadLine());
                    switch (AnswerDecide)
                    {
                        case 1:
                            {
                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("Add username and passowrd to login\n");
                                Console.ResetColor();
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
                                        case 5:
                                            {
                                                Menu.MenuSuperAdmin();
                                            }
                                            break;
                                        case 4:
                                            {
                                                Menu.MenuUserViewEditDelete(name);
                                            }
                                            break;
                                        case 3:
                                            {
                                                Menu.MenuUserViewEdit(name);
                                            }
                                            break;
                                        case 2:
                                            {
                                                Menu.MenuUserView(name);
                                            }
                                            break;
                                        case 1:
                                        default:
                                            {
                                                Menu.MenuUser(name);
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    Login.SignUp();
                                    check = false;
                                }
                                break;
                            }
                        case 2:
                        default:
                            {

                                if (Login.SignUp() == false)
                                {
                                    check = false;
                                }
                                break;
                            }
                    }
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }

            } while (check == true);
        }
    }
}


