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
    public class EnregistrementEvenementViewModel : BaseEvenementViewModel
    {
        public ICommand EnregistrementCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }
       




        public EnregistrementEvenementViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _evenement = new Evenement();
            _typeEvenement = new TypeEvenement();
            _evenementValidator = new EvenementValidator();



            EnregistrementCommand = new Command(async () => await EnregistrementEvenement());
            AnnulerCommand = new Command(async () => await Annuler());


            FetchTypeEvenement();

        }


        /// <summary>
        /// Afficher la liste des types evenements dans le picker
        /// </summary>
        /// <returns></returns>

        async Task FetchTypeEvenement()
        {
            EvenementListPicker = await new DatabaseHelper().TousLesTypesEvenementsAsync();
        }



        /// <summary>
        /// Enregistrer un evenement pour utilisateur
        /// </summary>
        /// <returns></returns>


        async Task EnregistrementEvenement()
        {
            var validation = _evenementValidator.Validate(_evenement);

            if (validation.IsValid)
            {

                bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageEnregistrement, Messages.MessageValidation, "Enregistrer", "Annuler");

                if (isUserAccept)
                {
                    _evenement.EnregistrerEnBase();
                   
                    var evenement = new DatabaseHelper().TousLesEvenements();
                    var eve = evenement.FindLast(p => p.nomEvenement != null);
                    if (App.MembreActuel == null)
                    {
                        App.MembreActuel = App.user;

                    }

                    App.MembreActuel.AjouterEvenement(eve);
                    
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
        /// Annuler la procedure enregistrement
        /// </summary>
        /// <returns></returns>

        async Task Annuler()
        {
            await PopupNavigation.Instance.PopAsync();
        }


    }
}