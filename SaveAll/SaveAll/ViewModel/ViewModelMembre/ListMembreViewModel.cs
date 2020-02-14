using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelMembre
{
    public class ListMembreViewModel : BaseMembreViewModel
    {


        public ICommand DeleteAllCommand { get; private set; }
        public ICommand AjouterCommand { get; private set; }

        public ListMembreViewModel(INavigation navigation)
        {
            _navigation = navigation;

            DeleteAllCommand = new Command(async () => await DeleteAllMembre());
            AjouterCommand = new Command(async () => await AddNewMembre());

            MessagingCenter.Subscribe<App>((App)Application.Current, "ActualiserListe", (sender) =>
            {
                FetchMembre();
            });

            FetchMembre();
        }



        /// <summary>
        /// Afficher la liste des membres pour un utilisateur
        /// </summary>
        /// <returns></returns>
        async Task FetchMembre()
        {

            MembreList = await App.MembreActuel.EnfantsAsync();            // fonctionnalite pour recuperer tous les enregistrements
        }


        /// <summary>
        /// Ajouter un nouveau membre
        /// </summary>
        /// <returns></returns>

        [Obsolete]
        async Task AddNewMembre()
        {
            var pr = new NouveauMembrePageView();
            
            await PopupNavigation.PushAsync(pr);

        }

        /// <summary>
        /// Supprimer tous les enregistrements
        /// </summary>
        /// <returns></returns>

        async Task DeleteAllMembre()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionTotal, "Supprimer", "Annuler");
            if (isUserAccept)
            {
              await  new DatabaseHelper().SupprimerTousLesMembreAsync();

            }
        }

        /// <summary>
        /// Afficher les details pour un enregistrement
        /// </summary>
        /// <param name="selectedMembreID"></param>
        /// <returns></returns>

        [Obsolete]
        async Task ShowMembreDetails(int selectedMembreID)
        {
            await _navigation.PushAsync(new DetailMembrePageView(selectedMembreID));
        }

        Membre _selectedItem;
        public Membre SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != null)
                {
                    _selectedItem = value;
                    NotifyPropertyChanged("SelectedItem");
                    ShowMembreDetails(value.Id);
                }
            }
        }
    }
}