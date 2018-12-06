using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class UserB:UserA 
    {
        userenum userenum;
        public UserB(string name) : base (name)
        {
            Name = name;
            userenum = userenum.userb;
        }
        public void WriteDatabase()
        {
            Console.WriteLine($"I am {Name} and i can Write in Database");
        }
    }
}
