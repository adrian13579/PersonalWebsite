using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PersonalWebsite.Components;
using PersonalWebsite.Components.Terminal;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<Shell>();

builder.Services.AddScoped<CommandLineParser>();

// create a dictionary of commands
builder.Services.AddScoped<IDictionary<string, ITerminalCommand>>(x =>
{
    var dictionary = new Dictionary<string, ITerminalCommand>();
    var commandTypes = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.GetInterfaces().Contains(typeof(ITerminalCommand)));
    foreach (var commandType in commandTypes)
    {
        var command = (ITerminalCommand)Activator.CreateInstance(commandType);
        dictionary.Add(command.Name, command);
    }
    return dictionary;
});

builder.Services.AddMudServices();

await builder.Build().RunAsync();
