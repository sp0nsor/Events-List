using Events.Application.Contracts.Registrations;
using FluentValidation;

namespace Events.API.Validators
{
    public class CreateRegistrationValidator : AbstractValidator<CreateRegistrationRequest>
    {
        public CreateRegistrationValidator()
        {
            RuleFor(x => x.EventId)
                .NotEmpty().WithMessage("Event ID is required.")
                .Must(BeAValidGuid).WithMessage("Event ID must be a valid GUID.");

            RuleFor(x => x.ParticipantId)
                .NotEmpty().WithMessage("Participant ID is required.")
                .Must(BeAValidGuid).WithMessage("Participant ID must be a valid GUID.");
        }

        private bool BeAValidGuid(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
