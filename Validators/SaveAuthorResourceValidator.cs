using BookStore.Resources;
using FluentValidation;

namespace BookStore.Validators
{
    public class SaveAuthorResourceValidator : AbstractValidator<SaveAuthorResource>
    {
        public SaveAuthorResourceValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(a => a.LastName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}