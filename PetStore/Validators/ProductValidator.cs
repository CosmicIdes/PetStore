using FluentValidation;

namespace PetStore.Validators
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Price).GreaterThan(0);
			RuleFor(x => x.Quantity).GreaterThan(0);
			RuleFor(x => x.Description).MinimumLength(10).When(x => x.Description != null);
		}
	}
}

