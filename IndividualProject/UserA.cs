using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class UserA:AbstractUser
    {
        
        public UserA()
        {            
            userlist = userenum.usera;
        }
        public void ViewDatabase()
        {
            Console.WriteLine($"i am {Name} and i can view database columns");
        }
    }
}
