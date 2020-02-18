using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelUtilisateur
{
    public class MiseAJourMotDePasseViewModel : BaseUtilisateurViewModel
    {
        
        public ICommand ValiderCommand { get; private set; }


        public MiseAJourMotDePasseViewModel(INavigation navigation, int membreId)
        {
            _navigation = navigation;
            _membre = new Membre();
            _membreModifPassword = new MembreModifPassword();
            _membre.Id = membreId;

            _validatorMiseAjourMotdePasse = new ValidateurMotDePasseMiseAJour();



            ValiderCommand = new Command(async () => await EnregistrementPassword());


            // AjoutImageProfil = new Command();

            FetchUserConnexionDetails();

        }

       
        /// <summary>
        /// Afficher info utilisateur
        /// </summary>

        private void FetchUserConnexionDetails()
        {

            _membre = new DatabaseHelper().MembreById();
            _membre.Pass = string.Empty;

        }




        /// <summary>
        /// Enregistrer password utilisateur
        /// </summary>
        /// <returns></returns>

        async Task EnregistrementPassword()
        {
            var validationDesInfos = _validatorMiseAjourMotdePasse.Validate(this);


            if (validationDesInfos.IsValid)
            {
                if (_membreModifPassword.PaswordIsValidForChange())
                {
                    _membre.Pass = _membre.Pass.EncodeMd5();
                    _membre.MisAjourEnBase();
                    await Application.Current.MainPage.DisplayAlert(Messages.MessageTitle, Messages.MessageAlerteMiseAJour, "OK");
                }

                else
                {
                    await Application.Current.MainPage.DisplayAlert("Desolé","mot de passe actuel n'est pas valide", "Ok");
                }



            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Desolé", validationDesInfos.Errors[0].ErrorMessage, "Ok");
            }




        }

    }

}
