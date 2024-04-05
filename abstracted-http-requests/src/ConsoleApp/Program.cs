using Core;
using Infrastructure.CatFactsApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddCatFactsApiClient(builder.Configuration.GetRequiredSection("CatFactsApiClient"));
builder.Services.AddTransient<IAnimalFactService, AnimalFactService>();

using IHost host = builder.Build();

var animalFactService = host.Services.GetService<IAnimalFactService>()!;
var fact = await animalFactService.GetRandomCatFactAsync();
Console.WriteLine(fact);

await host.RunAsync();