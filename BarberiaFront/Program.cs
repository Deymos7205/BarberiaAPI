using BarberiaFront;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System; // Agrega este using para Uri y HttpClient
using System.Net.Http; // Agrega este using para HttpClient

// Agrega los using para tus carpetas de servicios si los tienes
using BarberiaFront.Services; // Asumiendo que tus servicios están en esta carpeta

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// --- INICIO DE LAS MODIFICACIONES ---

// 1. Configurar la BaseAddress del HttpClient para que apunte a tu BarberiaAPI
// ¡MUY IMPORTANTE!: Reemplaza "https://localhost:7027/" con la URL real de tu BarberiaAPI.
// Puedes encontrarla ejecutando tu API y viendo la URL en el navegador (ej. el puerto que usa Swagger).
// Si tu API usa http en desarrollo, cámbialo a "http://localhost:XXXX".
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7176/") });

// 2. Registrar tus servicios personalizados
// Aquí debes registrar cada servicio que crees para interactuar con tus controladores de la API.
builder.Services.AddScoped<ClienteService>();
// builder.Services.AddScoped<GastoService>(); // Descomenta y agrega según los servicios que se creen
// builder.Services.AddScoped<HorarioService>();
// builder.Services.AddScoped<PagoService>();
// builder.Services.AddScoped<RolService>();
// builder.Services.AddScoped<TurnoService>();
// builder.Services.AddScoped<UsuarioService>();



await builder.Build().RunAsync();