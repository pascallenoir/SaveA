using System;
using FluentValidation;
using SaveAll.FrameworkMVVM;
using SaveAll.Interfaces;
using SaveAll.Model;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelUtilisateur
{
    public class BaseUtilisateurViewModel : ViewModelDeBase
    {
        public Membre _membre;
        public MembreModifPassword _membreModifPassword;

        public string _confirmPass { get; set; }
        public string _passActuel { get; set; }

        public ImMediaServices _mediaServices;
        public INavigation _navigation;
        public IValidator _validatorMiseAjourMotdePasse;
        public IValidator _validatorPaswordOublie;
        public IValidator _usernameValidation;
        public IValidator _validatorProfil;
        public IValidator _validatorQuestionSecuriteUn;
        public IValidator _utilisateurModelValidator;
        public IValidator _utilisateurLoginValidator;

        public string Login { get; set; }
        public string Pass { get; set; }
        public string ConfirmPass { get; set; }
        public string PassActuel { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaiss { get; set; }
        public string Sexe { get; set; }
        public string LieuNaiss { get; set; }
        public string GroupeSanguin { get; set; }
        public string Telephone { get; set; }
        public string Telephone2 { get; set; }
        public string Adresse { get; set; }
        public string Adresse2 { get; set; }
        public string Nationalite { get; set; }
        public string QuestionPiege { get; set; }
        public string Reponse { get; set; }
        public bool? Principal { get; set; }
        public DateTime? DateEnr { get; set; } = DateTime.Now;
        public DateTime? DateDerModif { get; set; } = DateTime.Now;
        public string TypeEnr { get; set; }
        public bool IsEditing { get; set; }
        public byte[] Photo { get; set; }
    }
}
