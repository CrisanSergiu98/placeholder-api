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

    public List<string> GetRandomStreetNames(int quantity)
    {
        List<string> streetNames = new List<string>();
        for (int i = 0; i < quantity; i++)
        {
            streetNames.Add(_streetNames[_random.Next(_streetNames.Count)]);
        }
        return streetNames;
    }

    public List<(string,string)> GetRandomCities(int quantity)
    {
        List<(string, string)> cities = new List<(string,string)>();
        for (int i = 0; i < quantity; i++)
        {
            cities.Add(_cities[_random.Next(_cities.Count)]);
        }
        return cities;
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
