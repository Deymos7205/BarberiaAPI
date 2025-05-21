using Microsoft.EntityFrameworkCore;
using BarberiaAPI.Data;
using BarberiaAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BarberiaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BarberiaConnection")));


builder.Services.AddSingleton(provider =>
    new BarberiaConexion(
        builder.Configuration.GetConnectionString("BarberiaConnection")!
    )
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.MapControllers();

app.Run();
