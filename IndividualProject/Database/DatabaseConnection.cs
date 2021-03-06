﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace IndividualProject
{
    

    class DatabaseConnection
    { 
        private readonly string connectionstring = Properties.Settings.Default.connectionString;

        public DatabaseConnection()
        {
            
        }

        public List<Accounts> SelectAccountTable()
        {
            List<Accounts> accounts = new List<Accounts>();
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("SelectAccounts", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var username = reader[0];
                        var userlevel = reader[1];                      
                        accounts.Add(new Accounts()
                        {
                            Username = Convert.ToString(username),
                            Userlevel = Convert.ToInt32(userlevel)
                        });
                    }
                }
                return accounts;
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
                if (username != "admin")
                {
                    PrintAffected.PrintAffectedRows(affected);
                }
            }

        }

        public void RemoveAccount(string username)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("RemoveAccountByUsername", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);

                var affected = cmd.ExecuteNonQuery();
                PrintAffected.PrintAffectedRows(affected);
            }

        }
        public void RemoveMessages(string username)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("RemoveMessagesByUsername", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);

                cmd.ExecuteNonQuery();
                
            }
        }
        public bool ValidateAccount(string name, string password)
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

        public bool ValidateUsername(string name)
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
                PrintAffected.PrintAffectedRows(affected);
            }
        }

        public int SelectUserlevelByUsername(string name)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();

                var cmd = new SqlCommand("SelectUserlevelByUsername", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", name);
                return Convert.ToInt32(cmd.ExecuteScalar());
               
            }
        }

        public UserRole GetUserAccess(string name, string password)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();

                var cmd = new SqlCommand("GetUserAccess", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Username", name);
                cmd.Parameters.AddWithValue("@Password", password);

                return (UserRole)Convert.ToInt32(cmd.ExecuteScalar());  

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
                PrintAffected.PrintAffectedRows(affected);
            }
        }

        public void AddMessage(string Sendername, string ReceiverName, string Message)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("AddMessage", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@sender", Sendername);
                cmd.Parameters.AddWithValue("@receiver", ReceiverName);
                cmd.Parameters.AddWithValue("@message", Message);

                var affected = cmd.ExecuteNonQuery();
                PrintAffected.PrintAffectedRows(affected);
            }
        }

        public void UpdateMessages(string Message, int id)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("UpdateMessages", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@messsage", Message);
                cmd.Parameters.AddWithValue("@MessagesId", id);

                var affected = cmd.ExecuteNonQuery();
                PrintAffected.PrintAffectedRows(affected);

            }
        }

        public List<Messages> ReadMessages(string Sendername, string Receivername)
        {
            List<Messages> messages = new List<Messages>();
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("ViewMessage", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@sendername", Sendername);
                cmd.Parameters.AddWithValue("@receivername", Receivername);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var datetime = reader[0];
                        var message = reader[1];
                        var id = reader[2];
                        var sendername = reader[3];
                        var receivername = reader[4];
                        messages.Add(new Messages()
                        {
                            Message = Convert.ToString(message),
                            TimeSent = Convert.ToDateTime(datetime),
                            SenderName = Convert.ToString(sendername),
                            ReceiverName = Convert.ToString(receivername),
                            MessagesId = Convert.ToInt32(id)
                        });
                    }
                }
                return messages;
            }
        }

        public List<Messages> ChooseMessagesBySendername(string Sendername)
        {
            List<Messages> messages = new List<Messages>();
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("ChooseMessage", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SenderName", Sendername);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var messageid = reader[0];
                        var message = reader[1];
                        var receivername = reader[2];
                        var timesent = reader[3];
                        messages.Add(new Messages()
                        {
                            Message = Convert.ToString(message),
                            SenderName = Sendername,
                            ReceiverName = Convert.ToString(receivername),
                            MessagesId = Convert.ToInt32(messageid),
                            TimeSent = Convert.ToDateTime(timesent)
                        });
                    }
                }
                return messages;
            }

        }
        public List<Messages> ChooseMessagesByReceivername(string receivername)
        {
            List<Messages> messages = new List<Messages>();
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("ViewMessages2", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@receivername", receivername);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var datetime = reader[0];
                        var message = reader[1];
                        var id = reader[2];
                        var sendername = reader[3];
                        messages.Add(new Messages()
                        {
                            Message = Convert.ToString(message),
                            TimeSent = Convert.ToDateTime(datetime),
                            SenderName = Convert.ToString(sendername),
                            ReceiverName = receivername,
                            MessagesId = Convert.ToInt32(id)
                        });
                    }
                }
                return messages;
            }

        }

        
        public List<Messages> ViewMessagesByName(string Sendername)
        {
            List<Messages> messages = new List<Messages>();
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("ViewMessagesByName", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", Sendername);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var datetime = reader[0];
                        var message = reader[1];
                        var id = reader[2];
                        var sendername = reader[3];
                        var receivername = reader[4];
                        messages.Add(new Messages()
                        {
                            Message = Convert.ToString(message),
                            TimeSent = Convert.ToDateTime(datetime),
                            SenderName = Convert.ToString(sendername),
                            ReceiverName = Convert.ToString(receivername),
                            MessagesId = Convert.ToInt32(id)
                        });
                    }
                    return messages;
                }
            }
        }

        public void DeleteMessagesById(int id)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("DeleteMessagesById", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MessagesId", id);
                var affected = cmd.ExecuteNonQuery();

                PrintAffected.PrintAffectedRows(affected);
            }

        }

        public string SelectMessageByID(int id)
        {
            var dbcon = new SqlConnection(connectionstring);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("SelectMessageByID", dbcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@messageid", id);
                var affected = cmd.ExecuteNonQuery();


                return Convert.ToString(cmd.ExecuteScalar());
                
            }

        }
    }
}
