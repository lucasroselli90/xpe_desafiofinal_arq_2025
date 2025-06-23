using XpeClienteApi.Data;
using XpeClienteApi.Models;
using XpeClienteApi.Repositories;
using XpeClienteApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteService>();


var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

// Cria o escopo de serviços para aplicar migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.Urls.Add("http://*:5078");

app.Run();
