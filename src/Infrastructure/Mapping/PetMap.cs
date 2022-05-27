using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mapping
{
    class PetMap : IEntityTypeConfiguration<Pet>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pet");

            builder.Property(x => x.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}