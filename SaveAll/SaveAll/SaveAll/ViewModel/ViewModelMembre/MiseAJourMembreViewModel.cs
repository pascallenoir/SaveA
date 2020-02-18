using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelMembre
{
    public class MiseAJourMembreViewModel : BaseMembreViewModel
    {

        public ICommand EnregistrementCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }



        public MiseAJourMembreViewModel(INavigation navigation, int selectedMembreID)
        {
            _navigation = navigation;
            _membreAjouterValidator = new MembreValidator();
            _membre = new Membre();
            _membre.Id = selectedMembreID;
            _typeMembre = new TypeMembre
            {
                IdTypeMembre = selectedMembreID
            };

            EnregistrementCommand = new Command(async () => await ModificationDesInfos());
            AnnulerCommand = new Command(async () => await retourDePage());

            FetchMembreDetailsAsync();
            FetchTypeMembre();

        }

        /// <summary>
        /// Bouton de retour
        /// </summary>
        /// <returns></returns>

        async Task retourDePage()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        /// <summary>
        /// Mise a jour des informations
        /// </summary>
        /// <returns></returns>

        async Task ModificationDesInfos()
        {
            var validation = _membreAjouterValidator.Validate(_membre);

            if (validation.IsValid)
            {

                bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageEnregistrement, Messages.MessageValidation, "Enregistrer", "Annuler");

                if (isUserAccept)
                {
                   _membre.MisAjourEnBase();
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
        /// Afficher les infos sur la page
        /// </summary>

        void FetchMembreDetailsAsync()
        {
            _membre = new DatabaseHelper().MembreById(_membre.Id);
        }

        /// <summary>
        /// Afficher la liste des type de membre dans le picker
        /// </summary>
        /// <returns></returns>

        async Task FetchTypeMembre()
        {
            TypeMembreList = await new DatabaseHelper().TousLesTypesMembres();
            _typeMembre = await new DatabaseHelper().TypeMembreById(_typeMembre.IdTypeMembre);

        }



    }
}
