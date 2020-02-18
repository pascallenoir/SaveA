using System;
using FluentValidation;
using SaveAll.Model;

namespace SaveAll.Validator
{
    public class ValidatorQuestionSecuriteUN : AbstractValidator<Membre>
    {
        public ValidatorQuestionSecuriteUN()
        {

            RuleFor(x => x.Reponse).NotNull().WithMessage(Messages.MessageNonNull);
          


        }
    }
}