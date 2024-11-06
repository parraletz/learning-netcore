using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeopleController : Controller
{
    
    private readonly IPeopleService _peopleService;
    
    public PeopleController(IPeopleService peopleService)
    {
        _peopleService = peopleService;
    }
    


    [HttpGet("all")]
    public List<People> GetPeople() => Repository.People;

    [HttpGet("{id}")]
    public ActionResult<People> Get(int id)
    {
        var person = Repository.People.FirstOrDefault((p => p.Id == id));

        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }
    
    [HttpGet("search/{search}")]
    public List<People> Get(string search) =>
        Repository.People.Where((p => p.Name.ToUpper().Contains((search.ToUpper())))).ToList();

    [HttpPost]
    public IActionResult Post(People person)
    {
        if (!_peopleService.Validate(person))
        {
            return BadRequest();
        }
        
        Repository.People.Add(person);
        
        return NoContent();
    }
}


public class Repository
{
    public static List<People> People = new List<People>
    {
        new People() 
            { Id = 1, Name = "John", BirthDate = new DateTime(1990, 1, 1) },
        new People() 
            { Id = 2, Name = "Jane", BirthDate = new DateTime(1990, 1, 1) },
        new People() 
            { Id = 3, Name = "Jack", BirthDate = new DateTime(1990, 1, 1) },
        new People() 
            { Id = 4, Name = "Joe", BirthDate = new DateTime(1990, 1, 1) },
    };
}

public class People
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
}