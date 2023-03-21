using Domain.Enums;

namespace Domain.Entities;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ReasonForTreatment { get; set; }
    public HealthStateEnum HealthState { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }
    public int AccommodationId { get; set; }
    public Accommodation Accommodation { get; set; }
}