using Placeholder.Domain.Abstractions;
using Placeholder.Domain.Models;

namespace Placeholder.Data.Repositories;

public class ProfilesRepository : IProfilesRepository
{
    private readonly IAddressRepository _addressRepository;
    private readonly List<string> _firstNames;
    private readonly List<string> _lastNames;
    private readonly Random _random = new();

    public ProfilesRepository(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
        _firstNames = LoadLines(Path.Combine(AppContext.BaseDirectory, "Data", "first_names.csv"));
        _lastNames = LoadLines(Path.Combine(AppContext.BaseDirectory, "Data", "last_names.csv"));
    }

    public async Task<List<string>> GetRandomFirstNames(int quantity)
    {
        var tasks = Enumerable.Range(0, quantity).Select(i => Task.Run(() =>
        {
            return _firstNames[_random.Next(_firstNames.Count)];
        }));
        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }

    public async Task<List<string>> GetRandomLastNames(int quantity)
    {
        var tasks = Enumerable.Range(0, quantity).Select(i => Task.Run(() =>
        {
            return _lastNames[_random.Next(_lastNames.Count)];
        }));
        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }

    private List<string> LoadLines(string path) =>
        File.ReadAllLines(path)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();   
}