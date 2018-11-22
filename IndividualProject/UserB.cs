using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class UserB:UserA 
    {
        public UserB(string name) : base (name)
        {
            Name = name;
        }
        public void WriteDatabase()
        {
            Console.WriteLine("I am userB and i can Write in Database");
        }
    }
}
