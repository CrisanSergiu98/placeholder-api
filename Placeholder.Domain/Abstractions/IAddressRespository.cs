namespace Placeholder.Domain.Abstractions;

public interface IAddressRepository
{
    List<string> GetRandomStreetNames(int quantity);
    List<(string, string)> GetRandomCities(int quantity);
}