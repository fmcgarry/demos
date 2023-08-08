using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class ServiceBusSubscriber
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusReceiver _receiver;
        //private readonly ServiceBusProcessor _processor;
        //private static string _topicName;

        public ServiceBusSubscriber(string topic, string connectionString)
        {
            //_topicName = topic;
            _client = new ServiceBusClient(connectionString);
            _receiver = _client.CreateReceiver(topic, "S1", new ServiceBusReceiverOptions());
            //_processor = _client.CreateProcessor(topic, "S1", new ServiceBusProcessorOptions());
        }

        public async Task<IEnumerable<Person>?> PeekPeople(CancellationToken token)
        {
            var messages = await _receiver.ReceiveMessagesAsync(maxMessages: 100, maxWaitTime: new TimeSpan(0, 0, 5), cancellationToken: token);

            if (messages is null)
            {
                Console.WriteLine("No messages found.");
                return null;
            }

            List<Person> people = new();

            foreach (var message in messages)
            {
                Person? person = System.Text.Json.JsonSerializer.Deserialize<Person>(message.Body.ToString());

                if (person is not null)
                {
                    people.Add(person);
                }
            }

            return people;
        }
    }
}