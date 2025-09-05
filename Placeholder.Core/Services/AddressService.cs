using Placeholder.Domain.Abstractions;

namespace Placeholder.Core.Services;

public class AddressService : IAddressService
{
    private readonly Random _random = new();
    private readonly IAddressRepository _addressRepository;
    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }
    public List<string> GetRandomAddresses(int quantity)
    {
        var addresses = new List<string>();
        var streetNames = _addressRepository.GetRandomStreetNames(quantity);
        var cities = _addressRepository.GetRandomCities(quantity);

        for (int i = 0; i < quantity; i++)
        {
            var houseNumber = _random.Next(1, 9999);
            var street = streetNames[i];
            var unit = _random.NextDouble() < 0.3 ? $"Apt {_random.Next(1, 999)}" : null;
            var (city, state) = cities[i];
            var zipCode = _random.Next(10000, 99999).ToString("D5");

            var fullAddress = $"{houseNumber} {street}" +
                              (unit != null ? $" {unit}" : "") +
                              $", {city}, {state} {zipCode}";

            addresses.Add(fullAddress);
        }

        return addresses;
    }
}