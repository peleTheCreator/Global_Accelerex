using FluentValidation;
using OpeningHours.Commands;

namespace OpeningHours.Validation
{
    public class CreateOpeningHoursCommandValidator : AbstractValidator<CreateOpeningHoursCommand>
    {
        public CreateOpeningHoursCommandValidator()
        {
            RuleFor(x => x)
                .NotEmpty();           
        }
    }
}
