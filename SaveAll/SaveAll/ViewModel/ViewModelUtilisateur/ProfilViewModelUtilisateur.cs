using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Media;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Services;
using SaveAll.Validator;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelUtilisateur
{
    public class ProfilViewModelUtilisateur : BaseUtilisateurViewModel
    {
        public ICommand ValiderProfilCommand { get; private set; }
        public ICommand AjoutImageProfil { get; private set; }
        public ICommand AllerAmiseAjourPassword { get; private set; }
        public ICommand SelectImageCommand { get; private set; }


        public ProfilViewModelUtilisateur(INavigation navigation)
        {
            _navigation = navigation;
            _membre = new Membre();
            _mediaServices = new MediaService();

            _validatorProfil = new ValideurProfilUtilisateur();


            SelectImageCommand = new Command(async () => await SelectImageCommandProfil());
            ValiderProfilCommand = new Command(async () => await EnregistrementProfil());
            AllerAmiseAjourPassword = new Command(async () => await AllerAmiseAjour());
            // AjoutImageProfil = new Command();

            FetchUserConnexionDetails();
           
        }





        async Task SelectImageCommandProfil()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Source", "Annuler", null, "Appareil photo", "Galerie");

            switch (action)
            {

                case ("Annuler"):

                    Console.WriteLine("Action: " + action);

                    break;

                case ("Galerie"):

                    var imageGallery = await _mediaServices.GetImageStreamAsync();

                    if (imageGallery != null)
                    {
                        Photo = imageGallery;
                    }


                    break;

                case ("Appareil photo"):

                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await Application.Current.MainPage.DisplayAlert("Savall", ":(Pas de camera disponible.", "OK");
                        return;
                    }
                    else
                    {

                    var imageCamera = await _mediaServices.PickAndShowFileAsync();

                    if (imageCamera != null)
                    {
                        Photo = imageCamera;
                    }

                    }

                    break;



            }
        }

        async Task AllerAmiseAjour()
        {
           await _navigation.PushAsync(new MiseAJourMotDePasseView(_membre.Id));
        }


        /// <summary>
        /// Afficher info utilisateur
        /// </summary> 

        private void FetchUserConnexionDetails()
        {
            
               if( App.MembreActuel == App.user)
            {
                _membre = new DatabaseHelper().MembreById();

            }
           

        }







        /// <summary>
        /// Enregistrer un utilisateur
        /// </summary>
        /// <returns></returns>

        async Task EnregistrementProfil()
        {
            var validationDesInfos = _validatorProfil.Validate(this);


            if (validationDesInfos.IsValid)
            {

                _membre.MisAjourEnBase();
                await Application.Current.MainPage.DisplayAlert(Messages.MessageTitle, Messages.MessageAlerteMiseAJour, "OK");
                MessagingCenter.Send<App>((App)Application.Current, "ActualiserInfosProfil");



            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Desolé", validationDesInfos.Errors[0].ErrorMessage, "Ok");
            }


           

        }
    
    }

}
