namespace Placeholder.Domain.Abstractions;

public interface IAddressService
{
    Task<List<string>> GetRandomAddresses(int quantity);
}