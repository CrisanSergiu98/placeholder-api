namespace Placeholder.Domain.Abstractions;

public interface IAddressRepository
{
    List<string> GetAddresses(int quantity);
}