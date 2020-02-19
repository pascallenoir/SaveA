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

namespace SaveAll.ViewModel.ViewModelEvenement
{
    public class ListEvementViewModel : BaseEvenementViewModel
    {

        
        public ICommand DeleteAllCommand { get; private set; }
        public ICommand AjouterCommand { get; private set; }


        public ListEvementViewModel(INavigation navigation)
        {
            _navigation = navigation;


            DeleteAllCommand = new Command(async () => await DeleteAllEvenements());
            AjouterCommand = new Command(async () => await AddNewEvenements());

            MessagingCenter.Subscribe<App>((App)Application.Current, "ActualiserListe", (sender) =>
            {
                FetchEvenements();
            });

            FetchEvenements();
        }

        /// <summary>
        /// Afficher la liste des evenements de lutilisateur
        /// </summary>
        /// <returns></returns>

        async Task FetchEvenements()
        {

            EvenementList.Clear();
            EvenementList.AddRange(await App.MembreActuel.SesEvenementsAsync());            // fonctionnalite pour recuperer tous les enregistrements
        }




        /// <summary>
        /// Ajouter un nouvel evenement
        /// </summary>
        /// <returns></returns>

        [Obsolete]
        async Task AddNewEvenements()
        {
            var pr = new NouvelEvenementPageView();
         
            await PopupNavigation.PushAsync(pr);

        }



        /// <summary>
        /// supprimer tout les enregistrements
        /// </summary>
        /// <returns></returns>
        async Task DeleteAllEvenements()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionTotal, "Supprimer", "Annuler");
            if (isUserAccept)
            {
                new DatabaseHelper().SupprimerTousLesEvenements();

            }
        }


        /// <summary>
        /// Afficher les details pour un enregistrement
        /// </summary>
        /// <param name="selectedEvenementID"></param>
        /// <returns></returns>

        [Obsolete]
        async Task ShowEvenementsDetails(int selectedEvenementID)
        {
            var pr = new DetailsEvenementPageView(selectedEvenementID);
           
            await _navigation.PushAsync(pr);
        }

        public Evenement SelectedItem { get; set; }

        void OnSelectedItemChanged()
        {
            ShowEvenementsDetails(SelectedItem.id);
        }
    }
}