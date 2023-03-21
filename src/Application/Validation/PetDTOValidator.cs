using Application.DTOs;
using FluentValidation;

namespace Application.Validation;

public class PetDTOValidator : AbstractValidator<PetDTO>
{
    public PetDTOValidator()
    {
        RuleFor(p => p.Name).NotEmpty().Length(3, 50);
        RuleFor(p => p.ReasonForTreatment).NotEmpty();
        RuleFor(p => p.HealthState).NotEmpty();
        RuleFor(p => p.AccommodationNumber).NotEmpty();
    }
}