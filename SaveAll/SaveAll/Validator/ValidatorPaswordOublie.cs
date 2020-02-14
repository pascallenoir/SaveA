using System;
using FluentValidation;
using SaveAll.ViewModel.ViewModelUtilisateur;

namespace SaveAll.Validator
{
    public class ValidatorPaswordOublie : AbstractValidator<BaseUtilisateurViewModel>
    {
        public ValidatorPaswordOublie()
        {
            RuleFor(x => x._membre.Pass).NotNull().Length(4, 20).WithMessage(Messages.MessagePassword);
            RuleFor(x => x.ConfirmPass).NotNull().Equal(x => x.Pass).WithMessage(Messages.Messagedontmatch);
        }
    }
}