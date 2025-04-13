using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StackExchange.Redis;
using System.Text;
using System.Threading.Channels;

namespace Vektorel.RMQ.FormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private IChannel channel;

        private async void Form1_Load(object sender, EventArgs e)
        {
            var redis = ConnectionMultiplexer.Connect("localhost:12003"); // Default Redis portu 6379'dur
            var redisDatabase = redis.GetDatabase();

            lblLstMessage.Text += await redisDatabase.StringGetAsync("last_message");

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 12000,
                UserName = "va249",
                Password = "vektorel16"
            };

            var connection = await factory.CreateConnectionAsync();
            if (connection is null)
            {
                throw new Exception("Baðlantý kurulamadý");
            }
            channel = await connection.CreateChannelAsync();

            // tüketici tanýmý, sürekli açýk kalmalý
            var consumer = new AsyncEventingBasicConsumer(channel);
            // tüketim anýnda çalýþacak kod olayý (event)
            consumer.ReceivedAsync += MessageReceived;

            //tüketimi baþlat
            await channel.BasicConsumeAsync("console.messages", false, consumer);
        }

        private async Task MessageReceived(object sender, BasicDeliverEventArgs @event)
        {
            //gelen mesajý oku çünkü mesaj byte array
            var message = Encoding.UTF8.GetString(@event.Body.ToArray());
            lstMessages.Invoke(() =>
            {
                lstMessages.Items.Add($"{DateTime.Now} - {message}");
            });

            //kuyruktan düþür
            await channel.BasicAckAsync(@event.DeliveryTag, false);
        }
    }
}
