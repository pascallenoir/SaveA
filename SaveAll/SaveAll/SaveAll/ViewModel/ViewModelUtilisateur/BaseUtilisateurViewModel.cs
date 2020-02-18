using FluentValidation;
using SaveAll.Controls;
using SaveAll.FrameworkMVVM;
using SaveAll.Helpers;
using SaveAll.Interfaces;
using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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




        public string Login
        {
            get => _membre.Login;
            set
            {
                _membre.Login = value;
                NotifyPropertyChanged("Login");
            }
        }

        public string Pass
        {
            get => _membre.Pass;
            set
            {
                _membre.Pass = value;
                NotifyPropertyChanged("Pass");
                
            }
        }



        public string ConfirmPass
        {
            get => _confirmPass;
            set
            {
                _confirmPass = value;
                NotifyPropertyChanged("ConfirmPass");
            }
        }


        public string PassActuel
        {
            get => _membreModifPassword.PassActuel;
            set
            {
                _membreModifPassword.PassActuel = value;
                NotifyPropertyChanged("PassActuel");
            }
        }




        public string Nom
        {
            get => _membre.Nom;
            set
            {
                _membre.Nom = value;
                NotifyPropertyChanged("Nom");
            }
        }


        
        public string Prenom
        {
            get => _membre.Prenom;
            set
            {
                _membre.Prenom = value;
                NotifyPropertyChanged("Prenom");
            }
        }

        public DateTime DateNaiss
        {
            get => _membre.DateNaiss;
            set
            {
                _membre.DateNaiss = value;
                NotifyPropertyChanged("DateNaiss");
            }
        }

        
        public string Sexe
        {
            get => _membre.Sexe;
            set
            {
                _membre.Sexe = value;
                NotifyPropertyChanged("Sexe");
            }
        }

       
        public string LieuNaiss
        {
            get => _membre.LieuNaiss ;
            set
            {
                _membre.LieuNaiss = value;
                NotifyPropertyChanged("LieuNaiss");
            }
        }

  
        public string GroupeSanguin
        {
            get => _membre.GroupeSanguin;
            set
            {
                _membre.GroupeSanguin = value;
                NotifyPropertyChanged("GroupeSanguin");
            }
        }

        public string Telephone
        {
            get => _membre.Telephone;
            set
            {
                _membre.Telephone = value;
                NotifyPropertyChanged("Telephone");
            }
        }

        public string Telephone2
        {
            get => _membre.Telephone2;
            set
            {
                _membre.Telephone2 = value;
                NotifyPropertyChanged("Telephone2");
            }
        }


        public string Adresse
        {
            get => _membre.Adresse;
            set
            {
                _membre.Adresse = value;
                NotifyPropertyChanged("Adresse");
            }
        }


        public string Adresse2
        {
            get => _membre.Adresse2;
            set
            {
                _membre.Adresse2 = value;
                NotifyPropertyChanged("Adresse2");
            }
        }


        public string Nationalite
        {
            get => _membre.Nationalite;
            set
            {
                _membre.Nationalite = value;
                NotifyPropertyChanged("Nationalite");
            }
        }


        public string QuestionPiege
        {
            get => _membre.QuestionPiege;
            set
            {
                _membre.QuestionPiege = value;
                NotifyPropertyChanged("QuestionPiege");
            }
        }

       
        public string Reponse
        {
            get => _membre.Reponse;
            set
            {
                _membre.Reponse = value;
                NotifyPropertyChanged("Reponse");
            }
        }

        public bool? Principal
        {
            get;
            set;
        }

   
        public DateTime? DateEnr
        {
            get;
            set;
        } = DateTime.Now;

        public DateTime? DateDerModif
        {
            get;
            set;
        } = DateTime.Now;

        public string TypeEnr
        {
            get;
            set;
        }


        public bool IsEditing
        {
            get;
            set;
        }


        public byte[] Photo
        {
            get => _membre.Photo;
            set
            {
               
                _membre.Photo = value;
                NotifyPropertyChanged("Photo");

                
            }

        }
    }
}
