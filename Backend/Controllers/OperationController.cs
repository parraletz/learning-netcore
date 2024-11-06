using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OperationController : ControllerBase
{
    [HttpGet]
    public decimal Add(decimal a, decimal b)
    {
        return a + b;
    }

    [HttpPost]
    public string Add(Posts posts, [FromHeader] string Host, [FromHeader(Name = "X-OCC-Version")] string version)
    {   
        Console.WriteLine(Host);
        Console.WriteLine(version);
        return posts.title + posts.tag;
    }
}

public class Posts
{
    public string title { get; set; }
    public string tag { get; set; }
}

