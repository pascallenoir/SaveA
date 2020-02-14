using System;
using FluentValidation;
using SaveAll.Model;

namespace SaveAll.Validator
{
    public class MembreValidator : AbstractValidator<Membre>
    {
        public MembreValidator()
        {
            RuleFor(x => x.Nom).NotNull().MaximumLength(30).WithMessage(Messages.MessageNonNull);
            RuleFor(x => x.Prenom).NotNull().WithMessage(Messages.MessageNonNull);


        }
    }
}