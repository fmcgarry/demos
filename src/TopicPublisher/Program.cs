using Microsoft.Extensions.Configuration;

// Build a config object, using env vars and JSON providers.
IConfiguration config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

// Get values from the config given their key and their target type.
Settings settings = config.GetRequiredSection(nameof(Settings)).Get<Settings>();
string connectionString = config.GetConnectionString("AzureServiceBus");