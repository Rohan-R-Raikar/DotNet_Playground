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
            .WithTcpServer("broker.hivemq.com", 1883) // Free public broker
            .WithCleanSession()
            .Build();

        await mqttClient.ConnectAsync(options);
        Console.WriteLine("Publisher connected to broker.");

        int count = 1;
        while (true)
        {
            string messagePayload = $"Temperature reading {count}";
            var message = new MqttApplicationMessageBuilder()
                .WithTopic("home/livingroom/temperature")
                .WithPayload(messagePayload)
                .WithAtLeastOnceQoS()
                .Build();

            await mqttClient.PublishAsync(message);
            Console.WriteLine($"Published: {messagePayload}");
            count++;
            await Task.Delay(2000); // wait 2 seconds
        }
    }
}
