using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure;

public class PetShopContext : DbContext
{
    public DbSet<Accommodation> Accommodations { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Owner> Owners { get; set; }

    public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accommodation>(x => x.ToTable("Accommodation"));
        modelBuilder.Entity<Pet>(x => x.ToTable("Pet"));
        modelBuilder.Entity<Owner>(x => x.ToTable("Owner"));
    }
}