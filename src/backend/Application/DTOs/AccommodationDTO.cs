using Domain.Enums;

namespace Application.DTOs
{
    public class AccommodationDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public AccommodationStateEnum State { get; set; }
    }
}