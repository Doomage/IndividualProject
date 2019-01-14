using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace IndividualProject
{
    class TransactedDataFile
    {
        private string DirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "IndividualProjectTextFiles");

        public  void TransactedDataSent(string Receivername, string message, string Sendername, DateTime dateTime)
        {
            CheckingIfDirectoryExists();
            var FilePath = CheckingIfFileExists(Sendername);
            using (TextWriter text = new StreamWriter(FilePath, true))
            {
                text.WriteLine($"{dateTime} User {Sendername} send to {Receivername} : {message}");
            }
        }

        public  void TransactedDataEdit(string Receivername, string message, string Sendername, DateTime dateTime)
        {
            CheckingIfDirectoryExists();
            var FilePath = CheckingIfFileExists(Sendername);
            using (TextWriter text = new StreamWriter(FilePath, true))
            {
                text.WriteLine($"{dateTime} User {Sendername} edit {Receivername}'s message: {message}");
            }
        }

        public  void DeleteMessageFile(string Receivername, string message, string Sendername, DateTime dateTime)
        {
            CheckingIfDirectoryExists();
            var FilePath = CheckingIfFileExists(Sendername);
            using (TextWriter text = new StreamWriter(FilePath, true))
            {
                text.WriteLine($"{dateTime} User {Sendername} delete {Receivername}'s message: {message}");
            }
        }

        private  string CheckingFileByUsername(string Sendername)
        {
            return DirectoryPath + "\\" + Sendername + ".txt";
        }

        public  void CheckingIfDirectoryExists()
        {
            try
            {
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "IndividualProjectTextFiles"));                    
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public  string CheckingIfFileExists(string Sendername)
        {
            try
            {
                if (!File.Exists(CheckingFileByUsername(Sendername)))
                {
                    var myfile = File.Create(CheckingFileByUsername(Sendername));
                    myfile.Close();
                }
            }
            catch (FileNotFoundException FNFE)
            {
                Console.WriteLine(FNFE.Message);
            }

            return DirectoryPath +"\\" + Sendername + ".txt";
        }

        public  void DeleteUserFile(string name)
        {
            CheckingIfDirectoryExists();
            var FilePath = CheckingIfFileExists(name);
            File.Delete(FilePath);
        }
    }
}



