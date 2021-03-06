﻿using Messages;
using Messages.Contracts;
using SimplePubSubBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePubSubBreakfast
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisherAddress = @".\Private$\simplePubSubSendIncoming";
            var incomingAddress = @".\Private$\simplePubSubSendManufacturer";

            var bus = new Bus(incomingAddress);
            bus.SubscribeToMessagesFrom<BreakfastFinishedEvent>(publisherAddress);

            Console.ReadLine();
        }
    }

    public class BreakfastHandler : IHandle<BreakfastFinishedEvent>
    {
        public void Handle(BreakfastFinishedEvent message)
        {
            Console.WriteLine("Ate a {0} breakfast by {1}", message.BreakfastType, message.FinishByWhen);
        }
    }
}