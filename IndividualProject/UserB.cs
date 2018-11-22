using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class UserB:User
    {
        public UserB(string name)
        {
            Name = name;
        }
        public void ViewDatabase()
        {
            Console.WriteLine("I am userb and i can view database columns");
        }
        public void WriteDatabase()
        {
            Console.WriteLine("I am userB and i can Write in Database");
        }
    }
}
