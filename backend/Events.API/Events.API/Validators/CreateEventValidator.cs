using Events.Application.Comands.Events.CreateEvent;
using FluentValidation;

namespace Events.API.Validators
{
    public class CreateEventValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.Place)
                .NotEmpty().WithMessage("Place is required.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.");

            RuleFor(x => x.MaxParticipantCount)
                .GreaterThan(0).WithMessage("MaxParticipantCount must be greater than 0.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Time is required.")
                .Must(BeAValidDate).WithMessage("Time must be a valid date.");

            RuleFor(x => x.Image)
                .NotNull().WithMessage("Image is required.")
                .Must(HaveValidImageFormat).WithMessage("Image must be a valid image file.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return date > DateTime.Now;
        }

        private bool HaveValidImageFormat(IFormFile image)
        {
            var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = System.IO.Path.GetExtension(image.FileName).ToLowerInvariant();
            return validExtensions.Contains(extension);
        }
    }
}
