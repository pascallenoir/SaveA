using FluentValidation;

using SaveAll.Model;
using SaveAll.ViewModel.ViewModelUtilisateur;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaveAll.Validator
{
    public class UtilisateurModelValidator : AbstractValidator<BaseUtilisateurViewModel>
    {
        public UtilisateurModelValidator()
        {
           
            RuleFor(x => x._membre.Login).NotNull().MaximumLength(30).WithMessage(Messages.MessageNonNull);
            RuleFor(x => x._membre.Pass).NotNull().Length(4,20).WithMessage(Messages.MessagePassword);
            RuleFor(x => x.ConfirmPass).NotNull().Equal(x => x.Pass).WithMessage(Messages.Messagedontmatch);
            

        }
    }
}