using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Mapping;

namespace Infrastructure
{
    public class SqLiteContext : DbContext
    {
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public SqLiteContext(DbContextOptions<SqLiteContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OwnerMap());
            modelBuilder.ApplyConfiguration(new PetMap());
            modelBuilder.ApplyConfiguration(new AccommodationMap());
        }
    }
}