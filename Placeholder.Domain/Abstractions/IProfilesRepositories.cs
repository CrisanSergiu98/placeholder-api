using Placeholder.Domain.Models;

namespace Placeholder.Domain.Abstractions;

public interface IProfilesRepository
{
    List<Profile> GetProfiles(int quantity);
}