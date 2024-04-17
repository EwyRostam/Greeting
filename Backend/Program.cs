using System.Reflection;
using Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", false, true)
.AddUserSecrets(Assembly.GetExecutingAssembly(), true)
.Build();
// Add services to the container.
builder.Services.AddDbContext<GreetingContext>(options =>
    options.UseSqlServer(config.GetConnectionString("GreetingContext") ??
    throw new InvalidOperationException("Connection string 'GreetingContext' not found.")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
