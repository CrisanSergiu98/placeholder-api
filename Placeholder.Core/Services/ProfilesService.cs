using Placeholder.Domain.Abstractions;
using Placeholder.Domain.Models;

namespace Placeholder.Core.Services;

public class ProfilesService : IProfilesService
{
    private readonly Random _random = new();
    private readonly IProfilesRepository _profilesRepository;
    private readonly IAddressService _addressService;

    public ProfilesService(
        IProfilesRepository profilesRepository,
        IAddressService addressService)
    {
        _profilesRepository = profilesRepository;
        _addressService = addressService;
    }

    public List<Profile> GetRandomProfiles(int quantity)
    {
        var profiles = new List<Profile>();
        var addresses = _addressService.GetRandomAddresses(quantity);
        var firstNames = _profilesRepository.GetRandomFirstNames(quantity);
        var lastNames = _profilesRepository.GetRandomLastNames(quantity);

        for (int i = 0; i < quantity; i++)
        {
            var firstName = firstNames[i];
            var lastName = lastNames[i];
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

    public List<string> GetRandomPhoneNumbers(int quantity)
    {
        List<string> phoneNumbers = new List<string>();
        for (int i = 0; i < quantity; i++)
        {
            phoneNumbers.Add(GeneratePhoneNumber());
        }
        return phoneNumbers;
    }

    public List<string> GetRandomDobs(int quantity)
    {
        List<string> dobs = new List<string>();
        for (int i = 0; i < quantity; i++)
        {
            dobs.Add(GenerateDob());
        }
        return dobs;
    }

    public List<string> GetRandomEmails(int quantity)
    {
        List<string> emails = new List<string>();
        var firstNames = _profilesRepository.GetRandomFirstNames(quantity);
        var lastNames = _profilesRepository.GetRandomLastNames(quantity);
        for (int i = 0; i < quantity; i++)
        {
            emails.Add(GenerateEmail(firstNames[i], lastNames[i]));
        }
        return emails;
    }

    public List<string> GetRandomNames(int quantity)
    {
        List<string> names = new List<string>();
        var firstNames = _profilesRepository.GetRandomFirstNames(quantity);
        var lastNames = _profilesRepository.GetRandomLastNames(quantity);
        for (int i = 0; i < quantity; i++)
        {
            names.Add($"{firstNames[i]} {lastNames[i]}" );
        }
        return names;
    }

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