using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var factory = new MqttFactory();
        var mqttClient = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("broker.hivemq.com", 1883)
            .WithCleanSession()
            .Build();

        mqttClient.UseConnectedHandler(async e =>
        {
            Console.WriteLine("Subscriber connected to broker.");

            await mqttClient.SubscribeAsync("home/livingroom/temperature");
            Console.WriteLine("Subscribed to topic: home/livingroom/temperature");
        });

        mqttClient.UseApplicationMessageReceivedHandler(e =>
        {
            string topic = e.ApplicationMessage.Topic;
            string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            Console.WriteLine($"Received message: {payload} from topic: {topic}");
        });

        await mqttClient.ConnectAsync(options);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

        await mqttClient.DisconnectAsync();
    }
}
