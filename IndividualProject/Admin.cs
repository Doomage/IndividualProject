﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class Admin:AbstractUser
    {
        userenum userenum;

        public Admin(string name,string psw)
        {
            Name = name;
            Password = psw;
            userenum = userenum.admin;
        }
       
    }
}
