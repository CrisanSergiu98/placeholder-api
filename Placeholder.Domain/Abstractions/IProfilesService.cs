using Placeholder.Domain.Models;

namespace Placeholder.Domain.Abstractions;

public interface IProfilesService
{
    Task<List<Profile>> GetRandomProfiles(int quantity);
    Task<List<string>> GetRandomPhoneNumbers(int quantity);
    Task<List<string>> GetRandomDobs(int quantity);
    Task<List<string>> GetRandomEmails(int quantity);
    Task<List<string>> GetRandomNames(int quantity);
}