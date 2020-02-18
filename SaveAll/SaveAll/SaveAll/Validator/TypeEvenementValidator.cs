using FluentValidation;
using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveAll.Validator
{
    public class TypeEvenementValidator : AbstractValidator<TypeEvenement>
    {
        public TypeEvenementValidator()
        {

            RuleFor(x => x.Nom).NotNull().WithMessage(Messages.MessageNonNull);

        }
    }
}
