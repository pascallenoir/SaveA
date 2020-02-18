using System;
using FluentValidation;
using SaveAll.Model;

namespace SaveAll.Validator
{
    public class ValidationUsername : AbstractValidator<Membre>
    {
        public ValidationUsername()
        {

            RuleFor(x => x.Login).NotNull().WithMessage(Messages.MessageNonNull);



        }
    }
}