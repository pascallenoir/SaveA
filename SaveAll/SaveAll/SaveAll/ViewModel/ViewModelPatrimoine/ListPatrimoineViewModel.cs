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

namespace SaveAll.ViewModel.ViewModelPatrimoine
{
    public class ListPatrimoineViewModel : BasePatrimoineViewModel
    {

        public ICommand DeleteAllCommand { get; private set; }
        public ICommand AjouterCommand { get; private set; }


        public ListPatrimoineViewModel(INavigation navigation)
        {
            _navigation = navigation;


            DeleteAllCommand = new Command(async () => await DeleteAllPatrimoine());
            AjouterCommand = new Command(async () => await AddNewPatrimoineSecond());


            MessagingCenter.Subscribe<App>((App)Application.Current, "ActualiserListe", (sender) =>
            {
                FetchPatrimoine();
            });

            FetchPatrimoine();


        }



        /// <summary>
        /// Afiicher la liste du patrimoine 
        /// </summary>
        /// <returns></returns>

        async Task FetchPatrimoine()
        {
            PatrimoineList.Clear();
            PatrimoineList.AddRange(await App.MembreActuel.SesBiens());            // fonctionnalite pour recuperer tous les enregistrements
        }


        /// <summary>
        /// Ajouter un nouveau biens
        /// </summary>
        /// <returns></returns>

        [Obsolete]
        async Task AddNewPatrimoineSecond()
        {
            var pr = new NouveauPatrimoinePageView();
            
            await PopupNavigation.PushAsync(pr);

        }


        /// <summary>
        /// Supprimer tous les enregistrements
        /// </summary>
        /// <returns></returns>
        /// 
        async Task DeleteAllPatrimoine()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionTotal, "Supprimer", "Annuler");
            if (isUserAccept)
            {
                await new DatabaseHelper().SupprimerTousLePatrimoineAsync();

            }
        }

        /// <summary>
        /// Afiicher les details pour un enregistrement
        /// </summary>
        /// <param name="selectedPatrimoineID"></param>
        /// <returns></returns>

        [Obsolete]
        async Task ShowPatrimoineDetails(int selectedPatrimoineID)
        {
            var pr = new DetailsPatrimoinePageView(selectedPatrimoineID);
           
            await _navigation.PushAsync(pr);
        }

        public Patrimoine SelectedItem { get; set; }

        // This method gets called because of PropertyChanged.Fody. Follows the convention: void On[MyProperty]Changed()
        void OnSelectedItemChanged()
        {
            ShowPatrimoineDetails(SelectedItem.Id);
        }
    }
}