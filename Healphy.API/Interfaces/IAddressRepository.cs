using Healphy.API.Models;

namespace Healphy.API.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> Create(Address address);
        Task<Address> Update(Address address);
        Task<Address> Delete(Address address);
        Task<IEnumerable<Address>> Get();
    }
}
