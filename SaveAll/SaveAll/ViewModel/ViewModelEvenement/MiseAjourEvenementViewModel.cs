using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelEvenement
{
    public class MiseAjourEvenementViewModel : BaseEvenementViewModel
    {

        public ICommand DeleteEvenementCommand { get; private set; }
        public ICommand EnregistrementCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }


        public MiseAjourEvenementViewModel(INavigation navigation, int selectedEvenementID)
        {
            _navigation = navigation;
            _evenementValidator = new EvenementValidator();
            _evenement = new Evenement
            {
                id = selectedEvenementID
            };


            DeleteEvenementCommand = new Command(async () => await DeleteEvenement());

            EnregistrementCommand = new Command(async () => await ModificationDesInfos());
            AnnulerCommand = new Command(async () => await retourDePage());

            FetchEvenementDetailsAsync();

            FetchTypeEvenement();



        }



        /// <summary>
        /// Afficher la liste des types evenements
        /// </summary>
        /// <returns></returns>


        async Task FetchTypeEvenement()
        {
            EvenementListPicker = await new DatabaseHelper().TousLesTypesEvenementsAsync();
        }

        /// <summary>
        /// Bouton retour
        /// </summary>
        /// <returns></returns>

        async Task retourDePage()
        {
            await PopupNavigation.Instance.PopAsync();
        }


        /// <summary>
        /// Mise a jour des informations sur un evenement
        /// </summary>
        /// <returns></returns>


        async Task ModificationDesInfos()
        {
            _evenement.MisAjourEnBase();

            var validation = _evenementValidator.Validate(_evenement);

            if (validation.IsValid)
            {

                bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageEnregistrement, Messages.MessageValidation, "Enregistrer", "Annuler");

                if (isUserAccept)
                {
                    _evenement.MisAjourEnBase();

                    await Application.Current.MainPage.DisplayAlert(Messages.MessageSucces, Messages.MessageOk, "OK");
                    await PopupNavigation.Instance.PopAsync();
                    MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");

                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(Messages.MessageTitleError, validation.Errors[0].ErrorMessage, "Ok");
            }

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