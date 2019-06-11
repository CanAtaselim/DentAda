using System;
using System.Messaging;

namespace DentAda.Common
{
    public class DentAda_Logging
    {
        public enum Type
        {
            Log = 0,
            Exception = 1,
            Event = 2
        }

        public static void WriteToQueue(Type Label, string Body)
        {
            CreateQueue();

            MessageQueue msqueue = new MessageQueue();
            msqueue.Path = @".\private$\DentAda";
            Message message = new Message();
            message.Formatter = new BinaryMessageFormatter();
            message.Label = Label.ToString();
            message.Body = Body;
            msqueue.Send(message);
            msqueue.Close();
        }
        public static void WriteToEventQueue(Type Label, string Body)
        {
            CreateEventQueue();

            MessageQueue msqueue = new MessageQueue();
            msqueue.Path = @".\private$\DentAda_Event";
            Message message = new Message();
            message.Formatter = new BinaryMessageFormatter();
            message.Label = Label.ToString();
            message.Body = Body;
            msqueue.Send(message);
            msqueue.Close();
        }

        #region  CreateQueue
        private static void CreateQueue()
        {
            if (!MessageQueue.Exists(@".\Private$\DentAda"))
            {
                MessageQueue.Create(@".\private$\DentAda");
            }
        }
        private static void CreateEventQueue()
        {
            if (!MessageQueue.Exists(@".\Private$\DentAda_Event"))
            {
                MessageQueue.Create(@".\private$\DentAda_Event");
            }
        }
        #endregion

        private static void ReadFromQueue()
        {

            MessageQueue queue = new MessageQueue();
            queue.Path = @".\private$\DentAda";

            Message message = queue.Receive();
            message.Formatter = new BinaryMessageFormatter();
            Console.WriteLine("Message Label: {0}", message.Label);
            Console.WriteLine("Message Body : {0}", message.Body);

            queue.Close();

        }
        private static void ReadFromEventQueue()
        {

            MessageQueue queue = new MessageQueue();
            queue.Path = @".\private$\DentAda_Event";

            Message message = queue.Receive();
            message.Formatter = new BinaryMessageFormatter();
            Console.WriteLine("Message Label: {0}", message.Label);
            Console.WriteLine("Message Body : {0}", message.Body);

            queue.Close();

        }
    }
}
