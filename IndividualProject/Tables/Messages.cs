﻿
using System;

namespace IndividualProject
{
    class Messages
    {
        public int MessagesId { get; set; }
        public DateTime TimeSent { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        

    }
}
