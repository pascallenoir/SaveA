using FluentValidation;
using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveAll.Validator
{
    public class TypeMembreValidator : AbstractValidator<TypeMembre>
    {
        public TypeMembreValidator()
        {

            RuleFor(x => x.NomTypeMembre).NotNull().WithMessage(Messages.MessageNonNull);

        }
    }
}
