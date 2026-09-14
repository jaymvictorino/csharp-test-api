using Microsoft.AspNetCore.Mvc;
using test_api.Models;
using test_api.Services;

namespace test_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private readonly PizzaService _pizzaService;

    public PizzaController(PizzaService pizzaService) => _pizzaService = pizzaService;

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => _pizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = _pizzaService.Get(id);

        if (pizza is null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        _pizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = _pizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();

        _pizzaService.Update(pizza);

        return NoContent();
    }
}
