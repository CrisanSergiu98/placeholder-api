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

    public List<Profile> GetProfiles(int quantity)
    {
        var profiles = new List<Profile>();
        var addresses = _addressRepository.GetAddresses(quantity);

        for (int i = 0; i < quantity; i++)
        {
            var firstName = _firstNames[_random.Next(_firstNames.Count)];
            var lastName = _lastNames[_random.Next(_lastNames.Count)];
            var address = addresses[i];
            var phone = GeneratePhoneNumber();
            var email = GenerateEmail(firstName, lastName);
            var dob = GenerateDob();

            profiles.Add(new Profile
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Phone = phone,
                Email = email,
                Dob = dob
            });
        }

        return profiles;
    }

    private List<string> LoadLines(string path) =>
        File.ReadAllLines(path)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();

    private string GeneratePhoneNumber()
    {
        var areaCode = _random.Next(200, 999);
        var exchange = _random.Next(200, 999);
        var subscriber = _random.Next(1000, 9999);
        return $"({areaCode}) {exchange}-{subscriber}";
    }

    private string GenerateEmail(string firstName, string lastName)
    {
        var domain = _random.NextDouble() < 0.5 ? "example.com" : "mail.com";
        return $"{firstName.ToLower()}.{lastName.ToLower()}{_random.Next(10, 99)}@{domain}";
    }

    private string GenerateDob()
    {
        var startDate = new DateTime(1950, 1, 1);
        var endDate = new DateTime(2005, 12, 31);
        var range = (endDate - startDate).Days;
        var randomDate = startDate.AddDays(_random.Next(range));
        return randomDate.ToString("yyyy-MM-dd");
    }
}