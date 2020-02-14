using System;
using System.Windows.Input;
using SaveAll.Model;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelUtilisateur
{
    public class ForgetPasswordUnViewModel : BaseUtilisateurViewModel
    {
        public ICommand PageSuivanteCommand { get; private set; }
        public ICommand RetourCommand { get; private set; }


        public ForgetPasswordUnViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _membre = new Membre();



            PageSuivanteCommand = new Command(() => PageSuivante());
            RetourCommand = new Command(() => RetourLogin());

        }

        private void RetourLogin()
        {
            _navigation.PushAsync(new IdentityCardpage());
        }

        private void PageSuivante()
        {
            _navigation.PushAsync(new ForgetPasswordPage3View());
        }

        
    }
}
