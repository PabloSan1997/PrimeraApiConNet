using Microsoft.AspNetCore.Mvc;
using primeraapi.Models;
using primeraapi.services;

namespace primeraapi.Controllers;

[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareasService tareasService;

    public TareaController(ITareasService service)
    {
        tareasService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareasService.Get());
    }
}