using Placeholder.Domain.Abstractions;
using Placeholder.Domain.Models;

namespace Placeholder.Core.Services;

public class ProfilesService: IProfilesService
{
    private readonly IProfilesRepository _profilesRepository;
    
    public ProfilesService(IProfilesRepository profilesRepository)
    {
        _profilesRepository = profilesRepository;
    }

    public List<Profile>GetRandomProfiles(int quantity)
    {
        return _profilesRepository.GetProfiles(quantity);
    }
}