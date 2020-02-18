using FluentValidation;
using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveAll.Validator
{
    public class TypePatrimoineValidator : AbstractValidator<TypePatrimoine>
    {
        public TypePatrimoineValidator()
        {

            RuleFor(x => x.NomTypePatrimoine).NotNull().WithMessage(Messages.MessageNonNull);

        }
    }
}
