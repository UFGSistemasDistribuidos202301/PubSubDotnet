using RabbitMQ.Client;

var factory = new ConnectionFactory()
{
	HostName = "rabbitmq"
};


using var connection = factory.CreateConnection();
// Console.WriteLine(connection.LocalPort);
// Console.WriteLine(connection.RemotePort);
using var channel = connection.CreateModel();

var exchangeName = "Publish-Subscribe";

channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Fanout);

while (true)
{
	var message = "";
	do
	{
		Console.Write("Publique uma mensagem: ");
		message = Console.ReadLine();
	}
	while (string.IsNullOrWhiteSpace(message));

	var body = System.Text.Encoding.UTF8.GetBytes(message);

	channel.BasicPublish(exchange: exchangeName, routingKey: "", basicProperties: null, body: body);

	Console.WriteLine("Mensagem publicada!");
}
