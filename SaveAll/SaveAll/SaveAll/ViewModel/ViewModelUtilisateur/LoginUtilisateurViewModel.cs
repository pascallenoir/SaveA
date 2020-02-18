using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelUtilisateur
{
    public class LoginUtilisateurViewModel : BaseUtilisateurViewModel
    {
        public ICommand LoginButtonCommand { get; private set; }
        public ICommand InscriptionCommand { get; private set; }
        public ICommand ForgetPasswordPageCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        private bool _state;
        public bool State
        {
            get => _state;
            set
            {
                _state = value;
                NotifyPropertyChanged("State");
            }
        }


        public LoginUtilisateurViewModel(INavigation navigation )
        {
            _navigation = navigation;
            _membre = new Membre();
            _utilisateurLoginValidator = new UtilisateurLoginValidator();

            if(MembreExtensions.nombreMembre() > 0)
            {
                LoginButtonCommand = new Command(async () => await LoginUtilisateur());
                ForgetPasswordPageCommand = new Command(async () => await PageMotDePasseOublie());
                ExitCommand = new Command(() => PageExit());

                InscriptionCommand = new Command(
                    execute: () =>
                {
                    
                    IsEditing = false;
                    State = false;


                    RefreshCanExecutes();
                },
            canExecute: () =>
            {
                return !IsEditing;
                
            });

            }
            else
            {
                LoginButtonCommand = new Command(async () => await LoginUtilisateur());
                InscriptionCommand = new Command(async () => await PageInscription(), () => State = true);
                ForgetPasswordPageCommand = new Command(async () => await PageMotDePasseOublie());
                ExitCommand = new Command(() => PageExit());
            }  

        }

        void RefreshCanExecutes()
            {
                (InscriptionCommand as Command).ChangeCanExecute();
                
            }

           
      

        async Task PageInscription()
        {
            await _navigation.PushAsync(new InscriptionView());
        }

        async Task PageMotDePasseOublie()
        {
            await _navigation.PushAsync(new ForgetPasswordPageView());
        }

          void PageExit()
        {
             System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        async Task LoginUtilisateur()
        {
            var validationDesInfos = _utilisateurLoginValidator.Validate(this);

            if (validationDesInfos.IsValid)
            {
                
                   if( _membre.LoginIsValid())
                {
                    await _navigation.PushAsync(new AccueilPageView());

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(Messages.MessageTitleValidator, Messages.Messageloginfail, "OK");
                }

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Desolé", validationDesInfos.Errors[0].ErrorMessage, "Ok");
            }
            

        }

       
    }
   
}
