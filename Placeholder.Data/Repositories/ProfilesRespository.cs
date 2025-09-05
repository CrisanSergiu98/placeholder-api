using Placeholder.Domain.Abstractions;
using Placeholder.Domain.Models;

namespace Placeholder.Data.Repositories;

public class ProfilesRepository : IProfilesRepository
{
    private readonly Profile[] _profiles = new Profile[]{
        new Profile(){FirstName = "A"},
        new Profile(){FirstName = "B"},
        new Profile(){FirstName = "C"},
        new Profile(){FirstName = "D"},
        new Profile(){FirstName = "E"},
        new Profile(){FirstName = "F"},
        new Profile(){FirstName = "G"},
        new Profile(){FirstName = "H"},
        new Profile(){FirstName = "I"},
        new Profile(){FirstName = "J"},
    };

    public List<Profile> GetProfiles(int quantity)
    {
        return _profiles.ToList();
    }
}