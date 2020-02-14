using System;
using FluentValidation;
using SaveAll.Model;

namespace SaveAll.Validator
{
    public class EvenementValidator : AbstractValidator<Evenement>
    {
        public EvenementValidator()
        {

            RuleFor(x => x.nomEvenement).NotNull().WithMessage(Messages.MessageNonNull);
            RuleFor(x => x.DateDeb).NotNull().WithMessage(Messages.MessageNonNull);

        }
    }
}
