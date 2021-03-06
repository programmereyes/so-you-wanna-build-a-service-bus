﻿using Messages;
using Messages.Contracts;
using RecoveryBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoveryReceive
{
    class Program
    {
        static void Main(string[] args)
        {
            var sendQueueAddress = @".\Private$\msmqrecoverySend";
            var receiveQueueAddress = @".\Private$\msmqrecoveryReceive";

            var bus = new Bus(receiveQueueAddress);

            bus.SubscribeToMessagesFrom<SimpleMessage>(sendQueueAddress);

            Console.ReadLine();
        }
    }

    public class ErrorOnceHandler : IHandle<SimpleMessage>
    {
        int numberOfErrors = 0;

        public void Handle(SimpleMessage message)
        {
            if (numberOfErrors++ < 1)
            {
                throw new NotImplementedException();
            }

            Console.WriteLine("Handled successfully");
        }
    }
}