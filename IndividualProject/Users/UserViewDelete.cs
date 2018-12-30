using System;
using System.Collections.Generic;

namespace IndividualProject
{
    class UserViewDelete:UserViewEdit
    {
        
        public UserViewDelete() : base()
        {           
            userlist = userenum.userc;
        }

        public override string UserMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------UserViewEditDelete Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1.Send a Message");
            Console.WriteLine("2.View your Messages");
            Console.WriteLine("3.View transacted message between 2 users");
            Console.WriteLine("4.Edit messages between 2 users");
            Console.WriteLine("5.Delete a message");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n0.Log Out");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public void DeleteMessages(string name)
        {

            Console.Clear();
            var MessageForFile = " " ;
            Console.Write("Type the User Name you want to delete his messages : ");
            var Sender = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            var db = new DatabaseConnection();
            var list = db.ChooseMessagesBySendername(Sender);
            var list2 = db.ChooseMessagesByReceivername(Sender);
            //kanw add ola ta antikeimena ths list2 sthn list meta ta kanw order 
            foreach (var element in list2)
            {
                list.Add(new Messages()
                {
                    Message = element.Message,
                    MessagesId = element.MessagesId,
                    SenderName = element.SenderName,
                    ReceiverName = element.ReceiverName,
                    TimeSent = element.TimeSent
                });
            }
            Console.WriteLine("\n");
            List<int> checkid = new List<int>();
            list.Sort((x, y) => string.Compare(Convert.ToString(x.TimeSent), Convert.ToString(y.TimeSent)));
            foreach (var x in list)
            {
                Console.WriteLine($"Message id {x.MessagesId}, {x.TimeSent} : {x.SenderName} send to {x.ReceiverName} : {x.Message}");
                checkid.Add(x.MessagesId);
            }
            Console.Write("\nWrite the Message id u want to delete or press enter to go back: ");
            var messageid = int.Parse(Console.ReadLine());
            bool checkmesssageid = true;
            do
            {                
                    if (checkid.Contains(messageid))
                    {
                        MessageForFile = DatabaseConnection.SelectMessageByID(messageid);
                        db.DeleteMessagesById(messageid);
                        checkmesssageid = false;
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Write the correct Message id : ");
                        Console.ResetColor();
                        messageid = int.Parse(Console.ReadLine());
                    }
            } while (checkmesssageid == true);
            TransactedDataFile.DeleteMessageFile(Sender, MessageForFile, name, DateTime.Now);
        }
    }
}
