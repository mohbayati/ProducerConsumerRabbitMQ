using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var cannection = factory.CreateConnection()) 
            using(var channel= cannection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                string messege = "Getting started with .Net core RabbitMQ";
                var body = Encoding.UTF8.GetBytes(messege);

                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine("Sent Message {0}", messege);

            }
            Console.WriteLine("Press [enter] to exit the sender");
            Console.ReadLine();
        }
    }
}
