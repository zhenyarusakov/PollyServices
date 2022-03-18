using Microsoft.AspNetCore.Mvc;
using RequestService.Interface;

namespace RequestService.Controllers;

[Route("api/[controller]")]
public class RequestController: ControllerBase
{
    private readonly IRequestService _requestService;

    public RequestController(IRequestService requestService)
    {
        _requestService = requestService;
    }

    [HttpGet]
    public async Task<IActionResult> MakeRequest()
    {
        var result = await _requestService.MakeRequest();
        
        return Ok(result);
    }
}