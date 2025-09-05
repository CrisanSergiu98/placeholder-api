using Placeholder.Domain.Models;

namespace Placeholder.Domain.Abstractions;

public interface IProfilesService
{
    List<Profile> GetRandomProfiles(int quantity);
}