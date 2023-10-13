
using Microsoft.AspNetCore.Mvc;
using primeraapi;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    TareasContext dbContext;
    public HelloWorldController(IHelloWorldService helloWorld, TareasContext db)
    {
        helloWorldService = helloWorld;
        dbContext=db;
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
    [HttpGet]
    public IActionResult CreateDataBase()
    {
        dbContext.Database.EnsureCreated();
        return Ok();
    }

}