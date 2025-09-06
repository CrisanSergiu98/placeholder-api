using Placeholder.Domain.Models;

namespace Placeholder.Domain.Abstractions;

public interface IProfilesRepository
{
    Task<List<string>> GetRandomFirstNames(int quantity);
    Task<List<string>> GetRandomLastNames(int quantity);
}