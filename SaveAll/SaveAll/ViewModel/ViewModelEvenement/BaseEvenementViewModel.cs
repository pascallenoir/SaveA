using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using FluentValidation;
using SaveAll.FrameworkMVVM;
using SaveAll.Model;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelEvenement
{
    public class BaseEvenementViewModel : ViewModelDeBase
    {

        public Evenement _evenement;
        public TypeEvenement _typeEvenement;
        public INavigation _navigation;
        public IValidator _evenementValidator;








        List<Evenement> _calendarInlineEvents;
        public List<Evenement> CalendarInlineEvents 
        {
            get => _calendarInlineEvents;
            set
            {
                _calendarInlineEvents = value;
                NotifyPropertyChanged("CalendarInlineEvents");
            }
        }



        public string nomEvenement
        {
            get => _evenement.nomEvenement;
            set
            {
                _evenement.nomEvenement = value;
                NotifyPropertyChanged("nomEvenement");
            }
        }


        public string Lieu
        {
            get => _evenement.Lieu;
            set
            {
                _evenement.Lieu = value;
                NotifyPropertyChanged("Lieu");
            }
        }


        // champs du type evenement

        public List<TypeEvenement> EvenementListPicker
        {
            get;
            set;
        }

        public string Nom
        {
            get => _typeEvenement.Nom;

            set
            {
                _typeEvenement.Nom = value;
                NotifyPropertyChanged("Nom");
            }
        }

        //fin

        public DateTime DateDeb
        {
            get => _evenement.DateDeb;
            set
            {
                _evenement.DateDeb = value;
                NotifyPropertyChanged("DateDeb");
            }
        }

        public DateTime? DateFin
        {
            get => _evenement.DateFin;
            set
            {
                _evenement.DateFin = value;
                NotifyPropertyChanged("DateFin");
            }
        }

        public DateTime? ProchainEvenemt
        {
            get => _evenement.ProchainEvenemt;
            set
            {
                _evenement.ProchainEvenemt = value;
                NotifyPropertyChanged("ProchainEvenemt");
            }
        }


      
        public string DescriptionEvenement
        {
            get => _evenement.DescriptionEvenement;
            set
            {
                _evenement.DescriptionEvenement = value;
                NotifyPropertyChanged("DescriptionEvenement");
            }
        }

      


        List<Evenement> _evenementList;
        public List<Evenement> EvenementList
        {
            get
            {
                List<Evenement> theCollection = new List<Evenement>();

                if (_evenementList != null)
                {
                    List<Evenement> entities = (from e in _evenementList
                                                where e.nomEvenement.Contains(_searchText)
                                               select e).ToList<Evenement>();
                    if (entities != null && entities.Any())
                    {
                        theCollection = new List<Evenement>(entities);
                    }
                }

                return theCollection;
            }
            set
            {
                _evenementList = value;
                NotifyPropertyChanged("EvenementList");
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
            NotifyPropertyChanged("EvenementList");
        }
        private bool CanExecuteSearchCommand()
        {
            return true;
        }

    }
}
