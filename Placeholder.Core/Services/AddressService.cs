using Placeholder.Domain.Abstractions;

namespace Placeholder.Core.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }
    public List<string> GetRandomAddresses(int quantity)
    {
        return _addressRepository.GetAddresses(quantity);
    }
}