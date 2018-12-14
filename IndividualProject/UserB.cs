using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class UserB:UserA 
    {
        
        public UserB() : base ()
        {           
            userlist = userenum.userb;
        }
        public void WriteDatabase()
        {
            Console.WriteLine($"I am {Name} and i can Write in Database");
        }
    }
}
