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
    public List<string> GetAddresses([FromHeader(Name = "X-API-Key")] string apiKey, int quantity)
    {
        return _addressService.GetRandomAddresses(quantity);
    }
}