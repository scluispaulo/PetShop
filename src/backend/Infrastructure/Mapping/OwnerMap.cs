using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mapping
{
    class OwnerMap : IEntityTypeConfiguration<Owner>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");

            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}