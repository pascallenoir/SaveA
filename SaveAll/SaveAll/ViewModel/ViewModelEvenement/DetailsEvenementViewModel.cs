using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelEvenement
{
    public class DetailsEvenementViewModel : BaseEvenementViewModel
    {

        public ICommand DeleteCommand { get; private set; }
        public ICommand MiseAjourPageCommand { get; private set; }


        public DetailsEvenementViewModel(INavigation navigation, int selectedEvenementID)
        {
            _navigation = navigation;
            _evenement = new Evenement
            {
                id = selectedEvenementID
            };

            _typeEvenement = new TypeEvenement
            {
                IdTypeEvenement = selectedEvenementID
            };



            DeleteCommand = new Command(async () => await DeleteEvenement());

            MiseAjourPageCommand = new Command(async () => await ModificationDesInfos());

            FetchEvenementDetailsAsync();

         

        }



        /// <summary>
        /// Mise a jour des informations sur un evenement
        /// </summary>
        /// <returns></returns>


        [Obsolete]
        async Task ModificationDesInfos()
        {
            var pr = new MiseAjourEvenementPageView(_evenement.id);

            await PopupNavigation.PushAsync(pr);

        }

        /// <summary>
        /// Afficher les informations sur la page
        /// </summary>

        private void FetchEvenementDetailsAsync()
        {
           _evenement = new DatabaseHelper().EvenementById(_evenement.id);
        }

        /// <summary>
        /// Supprimer un evenement
        /// </summary>
        /// <returns></returns>

        async Task DeleteEvenement()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionelement, "Supprimer", "Annuler");
            if (isUserAccept)
            {
                new DatabaseHelper().SupprimerEvenement(_evenement.id);
                await _navigation.PopAsync();
            }
        }
    }
}