using Domain.Enums;

namespace Domain.Entities
{
    public class Accommodation
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public AccommodationStateEnum State { get; set; }
        public Pet Pet { get; set; }
    }
}