using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class UserC:UserB
    {

        public UserC(string name) : base(name)
        {
            Name = name;
        }

        public void DeleteDatabaseColumn()
        {
            Console.WriteLine("I am userC and i can delete Database");
        }
    }
}
