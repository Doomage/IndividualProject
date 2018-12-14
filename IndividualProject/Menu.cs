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
            
        }
        public static void Admin()
        {
            var Admin = new Admin();
        }
        public static void UserA()
        {
            var userA = new UserA();
            userA.ViewDatabase();
        }
        public static void UserB()
        {
            var userB = new UserB();
            userB.ViewDatabase();
            userB.WriteDatabase();
                
        }
        public static void UserC()
        {
            var Admin = new UserC();
        }





    }
}
