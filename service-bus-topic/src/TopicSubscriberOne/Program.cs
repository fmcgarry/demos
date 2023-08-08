using Microsoft.Extensions.Configuration;
using SharedModels;

// Build a config object, using env vars and JSON providers.
IConfiguration config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

// Get values from the config given their key and their target type.
Settings settings = config.GetRequiredSection(nameof(Settings)).Get<Settings>();
string connectionString = config.GetConnectionString("AzureServiceBus");

var serviceBusFacade = new ServiceBusSubscriber(settings.TopicName, connectionString);

var cancellationToken = new CancellationTokenSource();

var people = await serviceBusFacade.PeekPeople(cancellationToken.Token);


if (people is not null)
{
    foreach (var person in people)
    {
        Console.WriteLine(person);
    }
}
else
{
    Console.WriteLine("No people found.");
}