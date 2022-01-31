using Azure.Messaging.ServiceBus;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicPublisher
{
    internal class ServiceBusPublisher
    {
        private static ServiceBusClient _client;
        private static ServiceBusSender _sender;

        public ServiceBusPublisher(string connectionString, string topic)
        {
            _client = new ServiceBusClient(connectionString);
            _sender = _client.CreateSender(topic);
        }

        public async Task<bool> SendPerson(Person person)
        {
            try
            {
                ServiceBusMessage message = CreateMessageFrom(person);
                await _sender.SendMessageAsync(message);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to publish {person}: {e}");
                return false;
            }
        }

        private static ServiceBusMessage CreateMessageFrom(Person person)
        {
            var serializedPerson = System.Text.Json.JsonSerializer.Serialize(person);
            var message = new ServiceBusMessage(body: serializedPerson);

            return message;
        }
    }
}
