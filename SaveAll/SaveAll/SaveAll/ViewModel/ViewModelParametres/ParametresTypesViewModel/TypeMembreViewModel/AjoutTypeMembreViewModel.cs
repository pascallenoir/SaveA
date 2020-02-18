using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelParametres.ParametresTypesViewModel.TypeMembreViewModel
{
    class AjoutTypeMembreViewModel : BaseTypeViewModel
    {
        public ICommand ValiderCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }


        public AjoutTypeMembreViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _typeMembre = new TypeMembre();
            _AjouterTypeMembreValidator = new TypeMembreValidator();


            ValiderCommand = new Command(async () => await EnregistrementDuType());
            AnnulerCommand = new Command(async () => await Annuler());


        }



        /// <summary>
        /// Enregistrer un type Patrimoine
        /// </summary>
        /// <returns></returns>

        async Task EnregistrementDuType()
        {
            var validation = _AjouterTypeMembreValidator.Validate(_typeMembre);

            if (validation.IsValid)
            {

                bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageEnregistrement, Messages.MessageValidation, "Enregistrer", "Annuler");

                if (isUserAccept)
                {

                    _typeMembre.EnregistrerEnBase();

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