using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQLibrary
{
    public  class RabbitMQSender: IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _exchangeName = "DemoExchange";
        private readonly string _routingKey = "demo-routing-key";
        private readonly string _queueName = "DemoQueue";

        public RabbitMQSender()
        {
            // Create and configure the connection factory
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672"),
                ClientProvidedName = "Rabbit Sender App"
            };

            // Create connection and channel
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declare exchange, queue, and bind them
            _channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(_queueName, false, false, false, null);
            _channel.QueueBind(_queueName, _exchangeName, _routingKey, null);
        }

        
        /// Sends a string message to RabbitMQ

        public void SendMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            byte[] messageBody = Encoding.UTF8.GetBytes(message);

            // Publish message to exchange using the routing key
            _channel.BasicPublish(_exchangeName, _routingKey, null, messageBody);
        }

        public void Dispose()
        {
            _channel.Dispose();
            _connection.Dispose();
        }

    }
}
