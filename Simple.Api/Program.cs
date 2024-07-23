using Simple.Api.Config;
using Simple.Api.Interfaces;
using Simple.Api.Service;
using StackExchange.Redis;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IWeatherService, WeatherService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var redisOptions = new RedisOptions();
builder.Configuration.GetSection("Redis").Bind(redisOptions);

var configurationOptions = new ConfigurationOptions
{
    AbortOnConnectFail = false,
    ResolveDns = true
};

foreach (var server in redisOptions.Servers)
{
    configurationOptions.EndPoints.Add(server);
}

var connection = ConnectionMultiplexer.Connect(configurationOptions);
builder.Services.AddSingleton<IConnectionMultiplexer>(connection);

builder.Services.AddSingleton(redisOptions);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
