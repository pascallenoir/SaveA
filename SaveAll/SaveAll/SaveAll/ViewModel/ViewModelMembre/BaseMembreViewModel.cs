using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using FluentValidation;
using MvvmHelpers;
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
        public bool? Principal { get; set; }
        public string SearchText { get; set; }
        /// <summary>
        /// INFOS TYPE MEMBRE
        /// </summary>
        /// 

        public List<TypeMembre> TypeMembreList { get; set; }
        public string NomTypeMembre { get; set; }
        public string TypeEnr { get; set; }

        public ObservableRangeCollection<Membre> MembreList { get; set; } = new ObservableRangeCollection<Membre>();
        public ObservableRangeCollection<Membre> SearchMembreList { get; set; } = new ObservableRangeCollection<Membre>();

        public MvvmHelpers.Commands.Command<string> SearchCommand { get; set; }

        public BaseMembreViewModel()
        {
            SearchCommand = new MvvmHelpers.Commands.Command<string>(searchText => DoSearchCommand(searchText));

            MembreList.CollectionChanged += MembreList_CollectionChanged;
        }

        private void MembreList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SearchMembreList.Clear();
            SearchMembreList.AddRange(MembreList);
        }

        void DoSearchCommand(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                SearchMembreList.Clear();
                SearchMembreList.AddRange(MembreList);
            }
            else
            {
                SearchMembreList.Clear();
                SearchMembreList.AddRange(MembreList.Where(x => x.Nom.Contains(searchText)));
            }
        }
    }
}
