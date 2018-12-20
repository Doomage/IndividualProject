﻿using System;
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
                var cmd = new SqlCommand("select username,userlevel from Accounts", dbcon);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var username = reader[0];
                        var PersonAccess = reader[1];
                        Console.WriteLine($" Username : {username}, PersonAccess : {PersonAccess}");
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
                var cmd = new SqlCommand("InsertAccount", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", psw);
                cmd.Parameters.AddWithValue("@PersonAccess", PersonAccess);

                var affected = cmd.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{affected} Affected rows");
                Console.ResetColor();
                Console.ReadKey();
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{affected} Affected rows");
                Console.ResetColor();
                Console.ReadKey();
            }

        }

        public static bool ValidateAccount(string name, string password)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
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
            }
        }

        public static bool ValidateUsername(string name)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
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

        public void AssignRoleBySuperAdmin(string name, int userlevel)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();               
                var cmd = new SqlCommand("AssignRoleBySuperAdmin", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", name);
                cmd.Parameters.AddWithValue("@userlevel", userlevel);
                var affected = cmd.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{affected} Affected rows");
                Console.ReadKey();
            }
        }

        public static bool SelectUserlevelByUsername(string name)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();

                var cmd = new SqlCommand("SelectUserlevelByUsername", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", name);
                if (cmd.ExecuteScalar().Equals(1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int GetUserAccess(string name, string password)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();

                var cmd = new SqlCommand("GetUserAccess", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", name);
                cmd.Parameters.AddWithValue("@Password", password);
                
                return Convert.ToInt32(cmd.ExecuteScalar());
                
            }

        }

        public void ChangeUserPassword(string name, string psw)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("CreateNewPassword", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", name);
                cmd.Parameters.AddWithValue("@password", psw);
                var affected = cmd.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{affected} Affected rows");
                Console.ReadKey();
            }
        }
    }
}
