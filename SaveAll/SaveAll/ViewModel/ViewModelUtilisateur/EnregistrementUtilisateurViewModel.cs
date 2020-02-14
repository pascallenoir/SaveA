using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using SaveAll.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelUtilisateur
{
    public class EnregistrementUtilisateurViewModel : BaseUtilisateurViewModel
    {
        public ICommand InscriptionCommand { get; private set; }
        public ICommand ImportationCommand { get; private set; }
        public ICommand ConnexionCommand { get; private set; }

        public EnregistrementUtilisateurViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _membre = new Membre();
            _utilisateurModelValidator = new UtilisateurModelValidator();

            
            InscriptionCommand = new Command(async () => await EnregistrementUtilisateur());
            ImportationCommand = new Command(async () => await PageImportation());
            ConnexionCommand = new Command(async () => await PageConnexion());
        }


        /// <summary>
        /// Aller a la page de connexion
        /// </summary>
        /// <returns></returns>

        async Task PageConnexion()
        {
            await _navigation.PushAsync(new IdentityCardpage());
        }


        /// <summary>
        /// Aller a la page importation
        /// </summary>
        /// <returns></returns>

        async Task PageImportation()
        {
            await _navigation.PushAsync(new ImportationPageView());
        }





        /// <summary>
        /// Enregistrer un utilisateur
        /// </summary>
        /// <returns></returns>

        async Task EnregistrementUtilisateur()
        {


            var validationDesInfos = _utilisateurModelValidator.Validate(this);


            if (validationDesInfos.IsValid)
            {

                _membre.Pass = _membre.Pass.EncodeMd5();

                _membre.EnregistrerEnBase();

                await Application.Current.MainPage.DisplayAlert(Messages.MessageTitle, Messages.MessageAlerteInscription, "OK");

                await _navigation.PushAsync(new IdentityCardpage());

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Desolé", validationDesInfos.Errors[0].ErrorMessage, "Ok");
            }

        }
    }
}

