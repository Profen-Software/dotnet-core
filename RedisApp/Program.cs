// See https://aka.ms/new-console-template for more information

using StackExchange.Redis;



var options = new ConfigurationOptions
{
    EndPoints = { "10.30.1.93:6379", "10.30.1.96:6379", "10.30.1.100:6379" },
    AbortOnConnectFail = false
};

// options.EndPoints.Add("10.30.1.93:6379");
// options.EndPoints.Add("10.30.1.96:6379");
// options.EndPoints.Add("10.30.1.100:6379");

var connection = await ConnectionMultiplexer.ConnectAsync(options);

var db = connection.GetDatabase();

Console.WriteLine("Connected to Redis");

await db.StringSetAsync("failover_3", "majeed");

var value = await db.StringGetAsync("failover_3");

Console.WriteLine(value);
