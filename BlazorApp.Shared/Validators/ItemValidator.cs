using FluentValidation;
using BlazorApp.Shared.Models;

namespace BlazorApp.Shared.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Le nom est obligatoire.")
                .MaximumLength(100).WithMessage("Le nom ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("La description ne doit pas dépasser 500 caractères.");
        }
    }
}
