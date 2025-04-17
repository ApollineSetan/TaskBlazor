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
                .MinimumLength(3).WithMessage("Le nom doit comporter au moins 3 caractères.")
                .MaximumLength(100).WithMessage("Le nom ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("La description ne doit pas dépasser 500 caractères.");
        }
    }
}
