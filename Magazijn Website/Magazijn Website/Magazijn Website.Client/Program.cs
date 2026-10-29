using Magazijn.Components.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<MagazijnService>();

await builder.Build().RunAsync();
