using Microsoft.Extensions.Configuration;
using SharedModels;
using TopicPublisher;

// Build a config object, using env vars and JSON providers.
IConfiguration config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

// Get values from the config given their key and their target type.
Settings settings = config.GetRequiredSection(nameof(Settings)).Get<Settings>();
string connectionString = config.GetConnectionString("AzureServiceBus");

var serviceBusFacade = new ServiceBusPublisher(connectionString, settings.TopicName);

Console.WriteLine("Enter a person...");
Console.Write("First Name: ");
var firstName = Console.ReadLine();
Console.Write("Last Name: ");
var lastName = Console.ReadLine();

bool isSuccess = await serviceBusFacade.SendPerson(new Person() { FirstName = firstName, LastName = lastName });

if (isSuccess)
{
    Console.WriteLine("Success");
}
else
{
    Console.WriteLine("Something happened!");
}