using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using SaveAll.Controls;
using SaveAll.Helpers;
using SaveAll.Model;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelUtilisateur
{
    public class MiseAjourUtilisateurViewModel : BaseUtilisateurViewModel
    {
        public ICommand EditCommand { get; private set; }
        public ICommand DefilutilisateurCommand { get; private set; }
        public ICommand DefilEtatCivilCommand { get; private set; }
        public ICommand DefilSecuriteCommand { get; private set; }
        public ICommand ValiderProfilCommand { get; private set; }
        public ICommand AjoutImageProfil { get; private set; }



        public MiseAjourUtilisateurViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _membre = new Membre();


            AjoutImageProfil = new Command(async () => await OnPickPhotoButtonClicked());
            EditCommand = new Command(async () => await PermettreEdition());

            DefilutilisateurCommand = new Command(async () => await PermettreEdition());

            DefilEtatCivilCommand = new Command(execute: () =>
            {

                IsEditing = false;

            },
            canExecute: () =>
            {
                return IsEditing = true ;
            });

            DefilSecuriteCommand = new Command(async () => await AfficherLesInfosSecurite());
            ValiderProfilCommand = new Command(async () => await EnregistrerOuMettreAjourInfosProfil());

            FetchProfilDetails();
        }

        async Task OnPickPhotoButtonClicked()
        {

            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
             //   Photo = byte[].FromStream(() => stream);
            }
        }

        private void FetchProfilDetails()
        {
            _membre =  new DatabaseHelper().MembreById();
        }

        async Task EnregistrerOuMettreAjourInfosProfil()
        {



            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageEnregistrement, Messages.MessageValidation, "Enregistrer", "Annuler");

            if (isUserAccept)
            {
                _membre.MisAjourEnBase();
                await Application.Current.MainPage.DisplayAlert(Messages.MessageSucces, Messages.MessageOk, "OK");


            }


        }

        async Task AfficherLesInfosSecurite()
        {

        }

        

        async Task AfficherLesInfosUtilisateur()
        {
            throw new NotImplementedException();
        }

        async Task PermettreEdition()
        {
            throw new NotImplementedException();
        }
    }
}