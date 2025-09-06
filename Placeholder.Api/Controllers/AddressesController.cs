using Microsoft.AspNetCore.Mvc;
using Placeholder.Domain.Abstractions;

namespace Placeholder.Api.Controllers;

[ApiController]
[Route("/addresses")]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;
    public AddressesController(IAddressService addressService)
    {
        _addressService = addressService;
    }
    [HttpGet]    
    public async Task<IActionResult> GetAddresses([FromHeader(Name = "X-API-Key")] string apiKey, int quantity)
    {
        var result = await _addressService.GetRandomAddresses(quantity);
        return Ok(result);
    }
}