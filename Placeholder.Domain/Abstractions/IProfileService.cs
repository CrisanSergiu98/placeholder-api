using Placeholder.Domain.Models;

namespace Placeholder.Domain.Abstractions;

public interface IProfilesService
{
    List<Profile> GetRandomProfiles(int quantity);
    List<string> GetRandomPhoneNumbers(int quantity);
    List<string> GetRandomDobs(int quantity);
    public List<string> GetRandomEmails(int quantity);
}