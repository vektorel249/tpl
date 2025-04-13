using RabbitMQ.Client;
using StackExchange.Redis;
using System.Text;

namespace Vektorel.RMQ.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Task.Run(async () =>
        {
            var redis = ConnectionMultiplexer.Connect("localhost:12003"); // Default Redis portu 6379'dur
            var redisDatabase = redis.GetDatabase();

            (var c, var o) = await CreateChannel();
            while (true)
            {
                Console.Write("Mesajınız....: ");
                var message = Console.ReadLine();
                if (string.IsNullOrEmpty(message))
                {
                    break;
                }
                await PublishMessage(c, message, redisDatabase);
                Console.WriteLine($"------ { DateTime.Now } Gönderildi ------");
            }

            c.Dispose();
            o.Dispose();
            
        }).Wait();
    }

    private static async Task PublishMessage(IChannel channel, string message, IDatabase redisDatabase)
    {
        await channel.BasicPublishAsync(exchange: "",
                                        routingKey: "console.messages",
                                        body: Encoding.UTF8.GetBytes(message));
        redisDatabase.StringSet("last_message", DateTime.Now.ToString());
    }

    private static async Task<(IChannel, IConnection)> CreateChannel()
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
        return (channel, connection);
    }

    #region Tuple yerine kullanılabilecek alternatifler
    record RabbitInfoRecord(IChannel Channel, IConnection Connection);
    class RabbitInfoClass
    {
        public IConnection Connection { get; set; }
        public IChannel Channel { get; set; }
    } 
    #endregion
}
