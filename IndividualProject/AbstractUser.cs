using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public enum userenum { usera = 1, userb = 2, userc = 3, admin = 4,superadmin = 5 }

    abstract class AbstractUser
    {
        protected DateTime DateofHiring;
        public string Name { get; set; }
        public userenum userlist { get; set; }
        public string Password { get; set; }
        
    }

}
