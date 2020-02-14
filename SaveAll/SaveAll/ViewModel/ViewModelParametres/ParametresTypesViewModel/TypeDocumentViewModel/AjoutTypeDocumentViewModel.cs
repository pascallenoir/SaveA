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

namespace SaveAll.ViewModel.ViewModelParametres.ParametresTypesViewModel.TypeDocumentViewModel
{
    class AjoutTypeDocumentViewModel : BaseTypeViewModel
    {
        public ICommand ValiderCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }


        public AjoutTypeDocumentViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _typeDocument = new TypeDocument();
            _AjouterTypeDocumentValidator = new TypeDocumentValidator();


            ValiderCommand = new Command(async () => await EnregistrementDuType());
            AnnulerCommand = new Command(async () => await Annuler());


        }



        /// <summary>
        /// Enregistrer un type Patrimoine
        /// </summary>
        /// <returns></returns>

        async Task EnregistrementDuType()
        {
            var validation = _AjouterTypeDocumentValidator.Validate(_typeDocument);

            if (validation.IsValid)
            {

                bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageEnregistrement, Messages.MessageValidation, "Enregistrer", "Annuler");

                if (isUserAccept)
                {

                    _typeDocument.EnregistrerEnBase();

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