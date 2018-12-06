using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProject
{
    public class Login
    {
        private Dictionary<string, string> Credentials = new Dictionary<string, string>();

        public Login(string name , string psw)
        {
            Credentials.Add(name,psw);
          
        }
        public bool ValidateCredentials(string username, string password)
        {
            return Credentials.Any(entry => entry.Key == username && entry.Value == password);
        }

    }
}
