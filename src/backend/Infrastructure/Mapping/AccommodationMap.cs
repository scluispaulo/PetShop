using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mapping
{
    class AccommodationMap : IEntityTypeConfiguration<Accommodation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Accommodation> builder)
        {
            builder.ToTable("Accommodation");

            builder.HasData(
                new Accommodation { Id = 1, Number = 1, State = Domain.Enums.AccommodationStateEnum.Free },
                new Accommodation { Id = 2, Number = 2, State = Domain.Enums.AccommodationStateEnum.Free },
                new Accommodation { Id = 3, Number = 3, State = Domain.Enums.AccommodationStateEnum.Free },
                new Accommodation { Id = 4, Number = 4, State = Domain.Enums.AccommodationStateEnum.Free },
                new Accommodation { Id = 5, Number = 5, State = Domain.Enums.AccommodationStateEnum.Free },
                new Accommodation { Id = 6, Number = 6, State = Domain.Enums.AccommodationStateEnum.Free },
                new Accommodation { Id = 8, Number = 8, State = Domain.Enums.AccommodationStateEnum.Free },
                new Accommodation { Id = 7, Number = 7, State = Domain.Enums.AccommodationStateEnum.Free },
                new Accommodation { Id = 9, Number = 9, State = Domain.Enums.AccommodationStateEnum.Free },
                new Accommodation { Id = 10, Number = 10, State = Domain.Enums.AccommodationStateEnum.Free }
            );
        }
    }
}