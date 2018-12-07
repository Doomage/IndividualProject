using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProject
{
    class Login:DictionaryForUsers
    {
        public Login(string name, string psw) : base(name, psw)
        {

        }


        public static bool ValidateCredentials(string name, string psw)
        {
            return Credentials.Any(entry => entry.Key == name && entry.Value == psw);
        }

    }
}
