namespace Placeholder.Domain.Abstractions;

public interface IAddressRepository
{
    Task<List<string>> GetRandomStreetNames(int quantity);
    Task<List<(string, string)>> GetRandomCities(int quantity);
}