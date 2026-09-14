using test_api.Models;

namespace test_api.Services;

public class PizzaService
{
    private readonly List<Pizza> _pizzas;
    private int _nextId = 3;

    public PizzaService()
    {
        _pizzas = new List<Pizza>
        {
            new()
            {
                Id = 1,
                Name = "Classic Italian",
                IsGlutenFree = false,
            },
            new()
            {
                Id = 2,
                Name = "Veggie",
                IsGlutenFree = true,
            },
        };
    }

    public List<Pizza> GetAll() => _pizzas;

    public Pizza? Get(int id) => _pizzas.FirstOrDefault(p => p.Id == id);

    public void Add(Pizza pizza)
    {
        pizza.Id = _nextId++;
        _pizzas.Add(pizza);
    }

    public void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;

        _pizzas.Remove(pizza);
    }

    public void Update(Pizza pizza)
    {
        var index = _pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        _pizzas[index] = pizza;
    }
}
