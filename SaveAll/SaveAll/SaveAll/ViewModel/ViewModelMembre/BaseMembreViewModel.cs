using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using FluentValidation;
using SaveAll.FrameworkMVVM;
using SaveAll.Model;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelMembre
{
    public class BaseMembreViewModel : ViewModelDeBase
    {
        public Membre _membre;
        public TypeMembre _typeMembre;

        public INavigation _navigation;
        public IValidator _membreAjouterValidator;
      


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
            get => _membre.LieuNaiss;
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




        public bool? Principal
        {
            get;
            set;
        }



        /// <summary>
        /// INFOS TYPE MEMBRE
        /// </summary>
        /// 

        public List<TypeMembre> TypeMembreList
        {
            get;
            set;
        }

        public string NomTypeMembre
        {
            get => _typeMembre.NomTypeMembre;

            set
            {
                _typeMembre.NomTypeMembre = value;
                NotifyPropertyChanged("NomTypeMembre");
            }
        }


        public string TypeEnr
        {
            get;
            set;
        }


        List<Membre> _membreList;
        public List<Membre> MembreList
        {
            get
            {
                List<Membre> theCollection = new List<Membre>();

                if (_membreList != null)
                {
                    List<Membre> entities = (from e in _membreList
                                             where e.Nom.Contains(_searchText)
                                               select e).ToList<Membre>();
                    if (entities != null && entities.Any())
                    {
                        theCollection = new List<Membre>(entities);
                    }
                    else
                    {

                    }
                }

                return theCollection;
            }

            set
            {
                _membreList = value;
                NotifyPropertyChanged("MembreList");
            }
        }


        private string _searchText = string.Empty;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value) { _searchText = value ?? string.Empty; NotifyPropertyChanged("SearchText"); }

                if (SearchCommand.CanExecute(null))
                {
                    SearchCommand.Execute(null);
                }
            }
        }



        private Command _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new Command(DoSearchCommand, CanExecuteSearchCommand);
                return _searchCommand;
            }
        }
        private void DoSearchCommand()
        {
            // Refresh the list, which will automatically apply the search text
            NotifyPropertyChanged("MembreList");
        }
        private bool CanExecuteSearchCommand()
        {
            return true;
        }

    }
}
