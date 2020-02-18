using System;
using FluentValidation;
using SaveAll.ViewModel.ViewModelUtilisateur;

namespace SaveAll.Validator
{
    public class UtilisateurLoginValidator : AbstractValidator<BaseUtilisateurViewModel>
    {
        public UtilisateurLoginValidator()
        {

            RuleFor(x => x._membre.Login).NotNull().MaximumLength(30).WithMessage(Messages.MessageNonNull);
            RuleFor(x => x._membre.Pass).NotNull().Length(4, 20).WithMessage(Messages.MessagePassword);
           

        }
    }
}