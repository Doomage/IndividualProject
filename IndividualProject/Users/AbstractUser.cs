﻿
namespace IndividualProject
{
    public enum userenum {user = 1, usera = 2, userb = 3, userc=4 ,superadmin = 5}

    abstract class AbstractUser
    {
        
        public string Name { get; set; }
        public userenum userlist { get; set; }
       
    }

}