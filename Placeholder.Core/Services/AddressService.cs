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
    public async Task<List<string>> GetRandomAddresses(int quantity)
    {
        var streetNames = await _addressRepository.GetRandomStreetNames(quantity);
        var cities = await _addressRepository.GetRandomCities(quantity);

        var tasks = Enumerable.Range(0, quantity).Select(i => Task.Run(() =>
        {
            var houseNumber = _random.Next(1, 9999);
            var street = streetNames[i];
            var unit = _random.NextDouble() < 0.3 ? $"Apt {_random.Next(1, 999)}" : null;
            var (city, state) = cities[i];
            var zipCode = _random.Next(10000, 99999).ToString("D5");

            return $"{houseNumber} {street}" +
                              (unit != null ? $" {unit}" : "") +
                              $", {city}, {state} {zipCode}";
        }));

        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }
}