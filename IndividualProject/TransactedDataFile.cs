using System;
using System.IO;

namespace IndividualProject
{
    class TransactedDataFile
    {
        const string DirectoryPath = @"C:\IndividualProject";

        public static void TransactedDataSent(string Receivername, string message, string Sendername, DateTime dateTime)
        {
            CheckingIfDirectoryExists();
            var FilePath = CheckingIfFileExists(Sendername);
            using (TextWriter text = new StreamWriter(FilePath, true))
            {
                text.WriteLine($"{dateTime} User {Sendername} send to {Receivername} : {message}");
            }
        }

        public static void TransactedDataEdit(string Receivername, string message, string Sendername, DateTime dateTime)
        {
            CheckingIfDirectoryExists();
            var FilePath = CheckingIfFileExists(Sendername);
            using (TextWriter text = new StreamWriter(FilePath, true))
            {
                text.WriteLine($"{dateTime} User {Sendername} edit {Receivername}'s message: {message}");
            }
        }
        public static void DeleteMessageFile(string Receivername, string message, string Sendername, DateTime dateTime)
        {
            CheckingIfDirectoryExists();
            var FilePath = CheckingIfFileExists(Sendername);
            using (TextWriter text = new StreamWriter(FilePath, true))
            {
                text.WriteLine($"{dateTime} User {Sendername} delete {Receivername}'s message: {message}");
            }
        }

        private static string CheckingFileByUsername(string Sendername)
        {
            return @"C:\IndividualProject\" + Sendername + ".txt";
        }

        public static void CheckingIfDirectoryExists()
        {
            try
            {
                if (!System.IO.Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
            }
            catch(UnauthorizedAccessException e)
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
        public static string CheckingIfFileExists(string Sendername)
        {            
                if (!File.Exists(CheckingFileByUsername(Sendername)))
                {
                    var myfile = File.Create(CheckingFileByUsername(Sendername));
                    myfile.Close();
                }
                return @"C:\IndividualProject\" + Sendername + ".txt";           
        }

    }
}
