using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using FluentValidation;
using MvvmHelpers;
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
        public List<Evenement> CalendarInlineEvents { get; set; }
        public string nomEvenement { get; set; }
        public string Lieu { get; set; }
        public List<TypeEvenement> EvenementListPicker { get; set; }
        public string Nom { get; set; }
        public DateTime DateDeb { get; set; }
        public TimeSpan HeureDeb { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime? ProchainEvenemt { get; set; }
        public string DescriptionEvenement { get; set; }
        public string SearchText { get; set; }
        public ObservableRangeCollection<Evenement> EvenementList { get; set; } = new ObservableRangeCollection<Evenement>();
        public ObservableRangeCollection<Evenement> SearchEvenementList { get; set; } = new ObservableRangeCollection<Evenement>();

        public MvvmHelpers.Commands.Command<string> SearchCommand { get; set; }

        public BaseEvenementViewModel()
        {
            SearchCommand = new MvvmHelpers.Commands.Command<string>(searchText => DoSearchCommand(searchText));

            EvenementList.CollectionChanged += EvenementList_CollectionChanged;
        }

        private void EvenementList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SearchEvenementList.Clear();
            SearchEvenementList.AddRange(EvenementList);
        }

        void DoSearchCommand(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                SearchEvenementList.Clear();
                SearchEvenementList.AddRange(EvenementList);
            }
            else
            {
                SearchEvenementList.Clear();
                SearchEvenementList.AddRange(EvenementList.Where(x => x.nomEvenement.Contains(searchText)));
            }
        }

    }
}
