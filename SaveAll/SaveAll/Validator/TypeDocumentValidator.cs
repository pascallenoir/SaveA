using FluentValidation;
using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveAll.Validator
{
    public class TypeDocumentValidator : AbstractValidator<TypeDocument>
    {
        public TypeDocumentValidator()
        {

            RuleFor(x => x.NomTypeDocument).NotNull().WithMessage(Messages.MessageNonNull);

        }
    }
}
