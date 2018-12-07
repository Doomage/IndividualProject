using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class DictionaryForUsers
    {
        public static Dictionary<string, string> Credentials = new Dictionary<string, string>();

        public DictionaryForUsers(string name,string psw)
        {
            Credentials.Add(name, psw);
        }









    }
}
