using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQLibrary
{
    public class RabbitMQReceiver : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private string _consumerTag;
        private readonly string _exchangeName = "DemoExchange";
        private readonly string _routingKey = "demo-routing-key";
        private readonly string _queueName = "DemoQueue";

        public RabbitMQReceiver()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672"),
                ClientProvidedName = "Rabbit Receiver App"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Setup exchange and queue
            _channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct);
            _channel.QueueDeclare(_queueName, false, false, false, null);
            _channel.QueueBind(_queueName, _exchangeName, _routingKey, null);
            _channel.BasicQos(0, 1, false); // One message at a time
        }

        // Starts consuming messages from the queue
        public void StartConsuming(Action<string> onMessageReceived)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                // Fire the event to notify subscribers of a new message
                onMessageReceived?.Invoke(message);

                // Acknowledge the message
                _channel.BasicAck(args.DeliveryTag, false);
            };
            _consumerTag = _channel.BasicConsume(_queueName, false, consumer);
        }

        public void StopConsuming()
        {
            if (!string.IsNullOrEmpty(_consumerTag))
                _channel.BasicCancel(_consumerTag);
        }
        public void Dispose()
        {
            StopConsuming();
            _channel?.Close();
            _connection?.Close();
        }
    }
}
