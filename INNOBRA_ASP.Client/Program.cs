using INNOBRA_ASP.Client;
using INNOBRA_ASP.Client.Servicios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<MensajeService>();

builder.Services.AddScoped<IHttpServicio, HttpServicio>();
builder.Services.AddScoped<AlertaServicio>();

await builder.Build().RunAsync();
