using Healphy.API.Data;
using Healphy.API.Interfaces;
using Healphy.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Healphy.API.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly HealphyDbContext _addressContext;
        public AddressRepository(HealphyDbContext context) 
        {
            _addressContext = context;
        }

        public async Task<Address> Create(Address address)
        {
            _addressContext.Add(address);
            await _addressContext.SaveChangesAsync();
            return address;
        }

        public async Task<Address> Delete(Address address)
        {
            _addressContext.Remove(address);
            await _addressContext.SaveChangesAsync();
            return address;
        }

        public async Task<IEnumerable<Address>> Get()
        {
            return await _addressContext.Address.ToListAsync();
        }

        public async Task<Address> Update(Address address)
        {
            _addressContext.Entry(address).State = EntityState.Modified;
            await _addressContext.SaveChangesAsync();
            return address;
        }
    }
}
