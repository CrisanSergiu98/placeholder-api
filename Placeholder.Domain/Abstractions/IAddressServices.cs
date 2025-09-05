namespace Placeholder.Domain.Abstractions;

public interface IAddressService
{
    List<string> GetRandomAddresses(int quantity);
}