using Microsoft.AspNetCore.Mvc;
using WebAPI.ExceptionHandler;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExceptionController : ControllerBase
{
    [HttpGet("notfound")]
    public IActionResult GetNotFound()
    {
        throw new NotFoundException("Aradığınız data bulunamadı.");
    }
    [HttpGet("validation")]
    public IActionResult GetValidation()
    {
        throw new ValidationException("Bazı validasyon hatalarınız bulunuyor.");
    }
    [HttpGet("badrequest")]
    public IActionResult GetBadRequest()
    {
        throw new BadRequestException("İsteğiniz başarısız oldu.");
    }
}
