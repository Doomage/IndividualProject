using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class UserC:UserB
    {
        userenum userenum;
        public UserC(string name) : base(name)
        {
            Name = name;
            userenum = userenum.userb;
        }

        public void DeleteDatabaseColumn()
        {
            Console.WriteLine($"I am {Name} and i can delete Database");

        }
    }
}
