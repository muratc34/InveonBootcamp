using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CacheExampleController : ControllerBase
{
    private List<Car> cars = new List<Car>()
    {
        new Car("Audi", "A3", 2015),
        new Car("BMW", "M4", 2014),
        new Car("Mercedes", "E200", 2020),
        new Car("Reanult", "Clio", 2023),
        new Car("Citroen", "C5 Aircross", 2020),
        new Car("Hyundai", "ix35", 2012),
        new Car("Toyota", "Corolla", 1998),
        new Car("Nissan", "Juke", 2015),
        new Car("Dacia", "Duster", 2012),
        new Car("Volswagen", "Caddy", 2007),
        new Car("Volvo", "XC90", 2018)
    };

    private readonly ICacheService _cacheService;

    public CacheExampleController(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var data = await _cacheService.GetAsync<List<Car>>("arabalar");

        if (data is null)
        {
            await _cacheService.SetAsync("arabalar", cars, TimeSpan.FromMinutes(20));
            return Ok(cars);
        }
        return Ok(data);
    }
}
