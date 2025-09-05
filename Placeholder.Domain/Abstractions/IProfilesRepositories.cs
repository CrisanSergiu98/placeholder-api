using Placeholder.Domain.Models;

namespace Placeholder.Domain.Abstractions;

public interface IProfilesRepository
{
    List<string> GetRandomFirstNames(int quantity);
    List<string> GetRandomLastNames(int quantity);
}