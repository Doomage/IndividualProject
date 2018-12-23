﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class User : AbstractUser
    {


        public User()
        {
            userlist = userenum.user;
        }

        public virtual string UserMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------User Menu----------");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1.Send a Message");
            Console.WriteLine("2.View your Messages");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("0.Log Out");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public void SendMessage(string name)
        {
            var db = new DatabaseConnection();
            Console.Clear();
            Console.Write("Type receiver name : ");
            string ReceiverName = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            Console.WriteLine("Type the message :");
            var Message = Console.ReadLine();
            db.AddMessage(name, ReceiverName, Message);
        }
        public void ViewMessage(string name)
        {
            Console.Clear();
            Console.Write("Type receiver name : ");
            string ReceiverName = Login.CheckingUsernameForChangeAccess(Console.ReadLine());
            Console.Clear();
            var list = ViewMessage(name, ReceiverName);
            var list2 = ViewMessage(ReceiverName, name);
            foreach (var element in list2)
            {
                list.Add(element);
            }
            list.Sort((x, y) => string.Compare(Convert.ToString(x.TimeSent), Convert.ToString(y.TimeSent)));
            foreach (var x in list)
            {
                Console.WriteLine($"{x.TimeSent} - {x.SenderName} send to {x.ReceiverName} : {x.Message}");
            }
            Console.ReadKey();
        }

        public List<Messages> ViewMessage(string sender, string receiver)
        {
            var db = new DatabaseConnection();
            return db.ReadMessages(sender, receiver);
        }
        
    }
}
