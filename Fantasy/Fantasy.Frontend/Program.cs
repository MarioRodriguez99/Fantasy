using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fantasy.Frontend;
using Fantasy.Frontend.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Inyectando servicios
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7113") });//Inyeccion HttpClient
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddLocalization();

await builder.Build().RunAsync();