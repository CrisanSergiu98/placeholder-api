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

    public async Task<List<string>> GetRandomStreetNames(int quantity)
    {
        var tasks = Enumerable.Range(0, quantity).Select(i => Task.Run(() =>
        {
            return _streetNames[_random.Next(_streetNames.Count)];
        }));
        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }

    public async Task<List<(string, string)>> GetRandomCities(int quantity)
    {
        var tasks = Enumerable.Range(0, quantity).Select(i => Task.Run(() =>
        {
            return _cities[_random.Next(_cities.Count)];
        }));
        var results = await Task.WhenAll(tasks);
        return results.ToList();
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
