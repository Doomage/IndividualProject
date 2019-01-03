﻿using System;
using System.IO;

namespace IndividualProject
{
    class TransactedDataFile
    {   
        const string path = @"C:\Users\Γιωργος\Desktop\GitHub\IndividualProject\TransactedDataFile.txt";

        public TransactedDataFile(string Receivername, string message, string Sendername)
        {
            CheckingIfFileExists();
            using (TextWriter text = new StreamWriter(path, true))
            {
                text.WriteLine($"User {Sendername} send to {Receivername} : {message}");
            }
        }

        public TransactedDataFile(string Receivername, string message, string Sendername, DateTime dateTime)
        {
            CheckingIfFileExists();
            using (TextWriter text = new StreamWriter(path, true))
            {
                text.WriteLine($"{dateTime} User {Sendername} edit {Receivername}'s message: {message}");
            }
        }
        public static void DeleteMessageFile(string Receivername, string message, string Sendername, DateTime dateTime)
        {
            CheckingIfFileExists();
            using (TextWriter text = new StreamWriter(path, true))
            {
                text.WriteLine($"{dateTime} User {Sendername} delete {Receivername}'s message: {message}");
            }
        }
        public static void CheckingIfFileExists()
        {      
            if (!File.Exists(path))
            {
               var myfile =  File.Create(path);
                myfile.Close();
            }            
        }
    }
}
