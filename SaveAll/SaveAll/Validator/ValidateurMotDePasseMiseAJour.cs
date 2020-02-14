using System;
using FluentValidation;
using SaveAll.ViewModel.ViewModelUtilisateur;

namespace SaveAll.Validator
{
    public class ValidateurMotDePasseMiseAJour : AbstractValidator<BaseUtilisateurViewModel>
    {
        public ValidateurMotDePasseMiseAJour()
        {
            RuleFor(x => x._membre.Pass).NotNull().Length(4, 20).WithMessage(Messages.MessagePassword);
            RuleFor(x => x.ConfirmPass).NotNull().Equal(x => x.Pass).WithMessage(Messages.Messagedontmatch);
            //RuleFor(x => x.PassActuel).NotNull().Length(4, 20).WithMessage(Messages.MessagePassword);
        }
    }
}