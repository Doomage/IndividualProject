using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class UserA:User
    {
        public UserA(string name)
        {
            Name = name;
        }
        public void ViewDatabase()
        {
            Console.WriteLine($"i am UserA {Name} and i can view database columns");
        }
    }
}
