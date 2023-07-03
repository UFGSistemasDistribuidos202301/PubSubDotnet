using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory()
{
	HostName = "rabbitmq"
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

var exchangeName = "Publish-Subscribe";
var queueName = channel.QueueDeclare().QueueName;

channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Fanout);
channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: "");

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, eventArgs) =>
{
	var message = System.Text.Encoding.UTF8.GetString(eventArgs.Body.ToArray());
	Console.WriteLine($"Mensagem recebida: {message}");
};

channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

Console.WriteLine("Subscriber " + queueName + " está aguardando por mensagens...");
Console.ReadLine();