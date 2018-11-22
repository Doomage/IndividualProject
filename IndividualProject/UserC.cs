using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class UserC:User
    {
       
        public UserC(string name )
        {
            Name = name;
        }
        public void ViewDatabase()
        {
            Console.WriteLine("I am userC and i can view database columns");
        }
        public void WriteDatabase()
        {
            Console.WriteLine("I am userC and i can Write in Database");
        }
        public void DeleteDatabaseColumn()
        {
            Console.WriteLine("I am userC and i can delete Database");
        }
    }
}
