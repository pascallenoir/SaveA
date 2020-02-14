using System;
using FluentValidation;
using SaveAll.Model;

namespace SaveAll.Validator
{
    public class DocumentValidator : AbstractValidator<Document>
    {
        public DocumentValidator()
        {

            RuleFor(x => x.nomDocument).NotNull().WithMessage(Messages.MessageNonNull);

        }
    }
}
