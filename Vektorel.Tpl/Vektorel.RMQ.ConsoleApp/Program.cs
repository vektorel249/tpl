using RabbitMQ.Client;
using System.Text;

namespace Vektorel.RMQ.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Task.Run(async () =>
        {
            (var c, var o) = await CreateChannel();
            while (true)
            {
                Console.Write("Mesajınız....: ");
                var message = Console.ReadLine();
                if (string.IsNullOrEmpty(message))
                {
                    break;
                }
                await PublishMessage(c, message);
                Console.WriteLine($"------ { DateTime.Now } Gönderildi ------");
            }

            c.Dispose();
            o.Dispose();
            
        }).Wait();
    }

    private static async Task PublishMessage(IChannel channel, string message)
    {
        await channel.BasicPublishAsync(exchange: "",
                                        routingKey: "console.messages",
                                        body: Encoding.UTF8.GetBytes(message));
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
