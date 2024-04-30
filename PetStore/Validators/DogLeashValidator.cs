using FluentValidation;

namespace PetStore.Validators
{
	public class DogLeashValidator : AbstractValidator<DogLeash>
	{
		public DogLeashValidator()
		{
			RuleFor(dogleash => dogleash.Name).NotNull();
			RuleFor(dogleash => dogleash.Price).GreaterThan(0);
			RuleFor(dogleash => dogleash.Quantity).GreaterThan(0);
			RuleFor(dogleash => dogleash.Description).MinimumLength(10).When(dogleash => dogleash.Description != null);
		}
	}
}

