using Healphy.API.Data;
using Healphy.API.Interfaces;
using Healphy.API.Models;

namespace Healphy.API.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly HealphyDbContext _addressContext;
        public AddressRepository(HealphyDbContext context) 
        {
            _addressContext = context;
        }

        public Task<Address> Create(Address address)
        {
            throw new NotImplementedException();
        }

        public Task<Address> Delete(Address address)
        {
            throw new NotImplementedException();
        }

        public Task<Address> Get(Address address)
        {
            throw new NotImplementedException();
        }

        public Task<Address> Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
