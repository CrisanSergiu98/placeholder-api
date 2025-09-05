using Placeholder.Domain.Abstractions;

namespace Placeholder.Data.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly List<string> _streetNames;
    private readonly List<(string City, string State)> _cities;
    private readonly Random _random = new();

    public AddressRepository()
    {
        _streetNames = LoadLines(Path.Combine(AppContext.BaseDirectory, "Data", "street_names.csv"));
        _cities = LoadCityStatePairs(Path.Combine(AppContext.BaseDirectory, "Data", "cities_states.csv"));
    }

    public List<string> GetAddresses(int quantity)
    {
        var addresses = new List<string>();

        for (int i = 0; i < quantity; i++)
        {
            var houseNumber = _random.Next(1, 9999);
            var street = _streetNames[_random.Next(_streetNames.Count)];
            var unit = _random.NextDouble() < 0.3 ? $"Apt {_random.Next(1, 999)}" : null;
            var (city, state) = _cities[_random.Next(_cities.Count)];
            var zipCode = _random.Next(10000, 99999).ToString("D5");

            var fullAddress = $"{houseNumber} {street}" +
                              (unit != null ? $" {unit}" : "") +
                              $", {city}, {state} {zipCode}";

            addresses.Add(fullAddress);
        }

        return addresses;
    }

    private List<string> LoadLines(string path) =>
        File.ReadAllLines(path)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();

    private List<(string City, string State)> LoadCityStatePairs(string path) =>
        File.ReadAllLines(path)
            .Select(line => line.Split(','))
            .Where(parts => parts.Length == 2)
            .Select(parts => (parts[0].Trim(), parts[1].Trim()))
            .ToList();
}
