using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProject
{
    class Login
    {
       private Dictionary<string, string> Credentials = new Dictionary<string, string>();
        string name { get; set; }
        string psw { get; set; }

        public Login(string name, string psw)
        {
            Credentials.Add(name, psw);
        }
        public  bool ValidateCredentials()
        {
            return Credentials.Any(entry => entry.Key == name && entry.Value == psw);
        }

    }
}
