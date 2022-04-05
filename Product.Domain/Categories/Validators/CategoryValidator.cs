using FluentValidation;
using Product.Domain.Categories.Entites;

namespace Product.Domain.Categories.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleSet("Add", () =>
            {
                RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} can't be empty.");
            });

            RuleSet("Update", () =>
            {
                RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} can't be empty.");

                RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} can't be empty.");
            });
        }
    }
}
