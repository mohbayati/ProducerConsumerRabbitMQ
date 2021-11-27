using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Receiver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var cannection = factory.CreateConnection())
            using (var channel = cannection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model,ea)=> 
                {
                    var body = ea.Body;
                    string message = body.ToString();
                    Console.WriteLine("Sent Message {0}", message);
                };
                channel.BasicConsume("BasicTest", true, consumer);
                Console.WriteLine("Press [enter] to exit the sender");
                Console.ReadLine();
            }
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
