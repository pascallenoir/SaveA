using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelMembre
{
    public class EnregistrementMembreViewModel : BaseMembreViewModel
    {
        public ICommand EnregistrementCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }
        

        public EnregistrementMembreViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _membre = new Membre();
            _typeMembre = new TypeMembre();
            _membreAjouterValidator = new MembreValidator();

            FetchTypeMembre();


            EnregistrementCommand = new Command(async () => await EnregistrementDuMembre());
            AnnulerCommand = new Command(async () => await Annuler());
          

        }


        /// <summary>
        /// Afficher la liste des type de membre dans le picker
        /// </summary>
        /// <returns></returns>

        async Task FetchTypeMembre()
        {
            TypeMembreList = await new DatabaseHelper().TousLesTypesMembres();
        }


        /// <summary>
        /// Enregistrer un membre
        /// </summary>
        /// <returns></returns>

        async Task EnregistrementDuMembre()
        {
            var validation = _membreAjouterValidator.Validate(_membre);

            if (validation.IsValid)
            {

                bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageEnregistrement, Messages.MessageValidation, "Enregistrer", "Annuler");

                if (isUserAccept)
                {
                    _membre.Mem_id = App.user.Id;
                    _membre.EnregistrerEnBase();
                   
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