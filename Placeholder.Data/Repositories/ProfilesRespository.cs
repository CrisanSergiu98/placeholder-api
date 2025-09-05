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

    public List<string> GetRandomFirstNames(int quantity)
    {
        List<string> firstNames = new List<string>();
        for (int i = 0; i < quantity; i++)
        {
            firstNames.Add(_firstNames[_random.Next(_firstNames.Count)]);
        }
        return firstNames;
    }

    public List<string> GetRandomLastNames(int quantity)
    {
        List<string> lastNames = new List<string>();
        for (int i = 0; i < quantity; i++)
        {
            lastNames.Add(_lastNames[_random.Next(_lastNames.Count)]);
        }
        return lastNames;
    }

    private List<string> LoadLines(string path) =>
        File.ReadAllLines(path)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();   
}