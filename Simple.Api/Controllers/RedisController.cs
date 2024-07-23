using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

[ApiController]
[Route("[controller]")]
public class RedisController : ControllerBase
{
    private readonly IConnectionMultiplexer _redis;

    public RedisController(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var db = _redis.GetDatabase();
        // await db.StringSetAsync("mykey", "myvalue");
        var value = await db.StringGetAsync("failover_3");
        return Ok(value.ToString());
    }
}
