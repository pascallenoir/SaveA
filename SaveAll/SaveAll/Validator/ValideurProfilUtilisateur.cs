using System;
using FluentValidation;
using SaveAll.ViewModel.ViewModelUtilisateur;

namespace SaveAll.Validator
{
    public class ValideurProfilUtilisateur : AbstractValidator<BaseUtilisateurViewModel>
    {
        public ValideurProfilUtilisateur()
        {

            RuleFor(x => x._membre.Login).NotNull().MaximumLength(30).WithMessage(Messages.MessageNonNull);
           

        }
    }
}