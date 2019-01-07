using System;

namespace IndividualProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Project Chat";
            SuperAdmin Sadmin = new SuperAdmin();
            Sadmin.CreateSuperAdmin();
            WelcomeMenu.ApplicationWelcomeMenu();
            var check = true;           
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1.Login\n2.Sign Up\n\n0.Exit");                   
                    var AnswerDecide = int.Parse(Console.ReadLine());
                    switch (AnswerDecide)
                    {
                        default:
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
                                                Menu.MenuSuperAdmin(name);
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
                                    WelcomeMenu.ApplicationWrongUsernameOrPassword();
                                }
                                break;
                            }
                        case 2:
                            {
                                Login.SignUp();                              
                                break;
                            }                       
                        case 0:                      
                            {
                                Console.Clear();
                                Console.WriteLine("Bye Bye");
                                check = false;
                                break;
                            }
                    }
                    Console.ReadKey();
                }               
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }              
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }

            } while (check == true);
        }
    }
}


