using System;
using System.Threading.Tasks;
using System.Windows.Input;
using SaveAll.Controls;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelUtilisateur
{
    public class AccueilViewModel : BaseUtilisateurViewModel
    {
        public ICommand DeconnexionCommand { get; private set; }
        public ICommand PhotoCommand { get; private set; }

        public AccueilViewModel(INavigation navigation) 
        {
            _navigation = navigation;
             _membre = new Membre();
         

           
            DeconnexionCommand = new Command(async () => await Deconnexion());

            MessagingCenter.Subscribe<App>((App)Application.Current, "ActualiserInfosProfil", (sender) =>
            {
                FetchUserConnexionDetails();

            });

            FetchUserConnexionDetails();
        }




        private void FetchUserConnexionDetails()
        {

            if (App.MembreActuel == App.user)
            {
                _membre = new DatabaseHelper().MembreById();

            }


        }



        private async Task Deconnexion()
        {
            await Application.Current.MainPage.DisplayAlert("Quitter","Voulez vous quitter l'application ?", "OK");
            Application.Current.Quit();

        }
    }
}
