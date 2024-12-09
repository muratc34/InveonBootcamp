using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaginationExampleController : ControllerBase
{
    static List<Fruit> fruitList = new List<Fruit>()
    {
        new Fruit("Muz", "Sarı"),
        new Fruit("Karpuz", "Yeşil"),
        new Fruit("Kavun", "Sarı"),
        new Fruit("Kiraz", "Kırmızı"),
        new Fruit("Çilek", "Kırmızı"),
        new Fruit("Armut", "Sarı"),
        new Fruit("Elma", "Kırmızı"),
        new Fruit("Nar", "Kırmızı"),
        new Fruit("Avakado", "Yeşil"),
        new Fruit("Portakal", "Turuncu"),
        new Fruit("Mandalina", "Turuncu"),
        new Fruit("Ananas", "Sarı"),
        new Fruit("Limon", "Sarı"),
        new Fruit("Hindistan Cevizi", "Kahverengi"),
        new Fruit("Muz", "Sarı"),
        new Fruit("Karpuz", "Yeşil"),
        new Fruit("Kavun", "Sarı"),
        new Fruit("Kiraz", "Kırmızı"),
        new Fruit("Çilek", "Kırmızı"),
        new Fruit("Armut", "Sarı"),
        new Fruit("Elma", "Kırmızı"),
        new Fruit("Nar", "Kırmızı"),
        new Fruit("Avakado", "Yeşil"),
        new Fruit("Portakal", "Turuncu"),
        new Fruit("Mandalina", "Turuncu"),
        new Fruit("Ananas", "Sarı"),
        new Fruit("Limon", "Sarı"),
        new Fruit("Hindistan Cevizi", "Kahverengi"),
        new Fruit("Muz", "Sarı"),
        new Fruit("Karpuz", "Yeşil"),
        new Fruit("Kavun", "Sarı"),
        new Fruit("Kiraz", "Kırmızı"),
        new Fruit("Çilek", "Kırmızı"),
        new Fruit("Armut", "Sarı"),
        new Fruit("Elma", "Kırmızı"),
        new Fruit("Nar", "Kırmızı"),
        new Fruit("Avakado", "Yeşil"),
        new Fruit("Portakal", "Turuncu"),
        new Fruit("Mandalina", "Turuncu"),
        new Fruit("Ananas", "Sarı"),
        new Fruit("Limon", "Sarı"),
        new Fruit("Hindistan Cevizi", "Kahverengi")
    };

    private readonly PaginationService _paginationService;

    public PaginationExampleController(PaginationService paginationService)
    {
        _paginationService = paginationService;
    }

    [HttpGet]
    public IActionResult Get(int pageNum, int pageSize) 
    {
       return Ok(_paginationService.GetPagination(fruitList, pageNum, pageSize));
    }
}
