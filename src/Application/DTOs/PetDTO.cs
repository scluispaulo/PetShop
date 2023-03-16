namespace Application.DTOs
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReasonForTreatment { get; set; }
        public int HealthState { get; set; }
        public int AccommodationNumber { get; set; }
        public int OwnerId { get; set; }
        public OwnerDTO OwnerDTO { get; set; }
    }
}