using Healphy.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Healphy.API.Data;
public class HealphyDbContext : DbContext
{
    public HealphyDbContext(DbContextOptions<HealphyDbContext> options) : base(options) {}

    public DbSet<Address> Address { get; set; }
    public DbSet<Appointment> Appointment { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
}

