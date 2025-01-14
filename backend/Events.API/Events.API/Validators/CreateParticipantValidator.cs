using Events.Application.Comands.Participants.CreateParticipant;
using FluentValidation;

namespace Events.API.Validators
{
    public class CreateParticipantValidator : AbstractValidator<CreateParticipantCommand>
    {
        public CreateParticipantValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Birth date is required.")
                .Must(BeAValidBirthDate).WithMessage("Birth date must be in the past.");
        }

        private bool BeAValidBirthDate(DateTime birthDate)
        {
            return birthDate < DateTime.Now.AddYears(-18);
        }
    }
}
