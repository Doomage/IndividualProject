using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace IndividualProject
{


    class DatabaseConnection
    {
        private static string connectionstring = "Server= DESKTOP-OJEQUAD\\SQLEXPRESS; Database= IndividualProject;Integrated Security = SSPI;";

        public DatabaseConnection()
        {
        }

        public void SelectAccountTable()
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("select * from accounts", dbcon);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var username = reader[0];
                        var Password = reader[1];
                        var PersonAccess = reader[2];
                        var PErsonid = reader[3];

                        Console.WriteLine($" Username : {username}, Password : {Password}, PersonAccess : {PersonAccess}, PersonID : {PErsonid}");
                    }
                }

            }
        }

        public void AddAccount(string username, string psw, int PersonAccess)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("insert into Accounts values(@username,@Password,@PersonAccess)", dbcon);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@Password", psw);
                cmd.Parameters.AddWithValue("@PersonAccess", PersonAccess);

                var affected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{affected} Affected rows");

            }

        }
        public void RemoveAccount(string username)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("delete from Accounts where Username = '" + username + "'", dbcon);
                var affected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{affected} Affected rows");
            }

        }

        public static bool ValidateAccount(string name, string password)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                //TODO an auto gurisei true tote uparxei to psw else zita
                var cmd = new SqlCommand("Validate_Account", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", name);
                cmd.Parameters.AddWithValue("@Password", password);
                if (cmd.ExecuteScalar().Equals(1))
                {
                    return true;
                }
                else
                {
                    return false;
                }

                //Console.WriteLine(cmd.Parameters["@Password"].Value);

            }

        }

        public static bool ValidateUsername(string name)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                //TODO an auto gurisei true tote uparxei to psw else zita
                var cmd = new SqlCommand("Validate_Username", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", name);
                if (cmd.ExecuteScalar().Equals(1))
                {
                    return true;               
                }
                else
                {
                    return false;
                }

                //Console.WriteLine(cmd.Parameters["@Password"].Value);

            }

        }
    }
}
