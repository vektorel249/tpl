using RabbitMQ.Client;
using System.Text;

namespace Vektorel.RMQ.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Task.Run(async () =>
        {
            using var channel = await CreateChannel();
            while (true)
            {
                Console.Write("Mesajınız....: ");
                var message = Console.ReadLine();
                if (string.IsNullOrEmpty(message))
                {
                    break;
                }
                await PublishMessage(channel, message);
                Console.WriteLine($"------ { DateTime.Now } Gönderildi ------");
            }
            
        }).Wait();
    }

    private static async Task PublishMessage(IChannel channel, string message)
    {
        await channel.BasicPublishAsync(exchange: "",
                                        routingKey: "console.messages",
                                        body: Encoding.UTF8.GetBytes(message));
    }

    private static async Task<IChannel> CreateChannel()
    {
        var factory = new ConnectionFactory();
        factory.HostName = "localhost";
        factory.Port = 12000;
        factory.UserName = "va249";
        factory.Password = "vektorel16";

        var connection = await factory.CreateConnectionAsync();
        if (connection is null)
        {
            throw new InvalidOperationException("Bağlantı kurulamadı");
        }

        var channel = await connection.CreateChannelAsync();
        await channel.QueueDeclareAsync("console.messages", true, false, false);
        return channel;
    }
}
