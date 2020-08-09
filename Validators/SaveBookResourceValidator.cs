using BookStore.Resources;
using FluentValidation;

namespace BookStore.Validators
{
    public class SaveBookResourceValidator : AbstractValidator<SaveBookResource>
    {
        public SaveBookResourceValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.AuthorId)
                .NotEmpty()
                .WithMessage("'Author Id' must not be 0.");
        }
    }
}