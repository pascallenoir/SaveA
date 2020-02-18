using System;
using System.Windows.Input;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelUtilisateur
{
    public class ForgetPasswordTroisViewModel : BaseUtilisateurViewModel
    {
        public ICommand ValidationCommand { get; private set; }



        public ForgetPasswordTroisViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _membre = new Membre();
            _usernameValidation = new ValidationUsername();


            ValidationCommand = new Command(() => Validation());

        }



        /// <summary>
        /// Valider Login untilisateur
        /// </summary>

        private void Validation()
        {
            var validationDesInfos = _usernameValidation.Validate(_membre);


            if (validationDesInfos.IsValid)
            {
                if (_membre.UsernameIsValid())
                {

                    Application.Current.MainPage.DisplayAlert(Messages.MessageTitleVerification, Messages.MessageVerificationUsername, "Ok");

                    _navigation.PushAsync(new ForgetPasswordPage2View(_membre.Id));


                }
                else
                {
                    Application.Current.MainPage.DisplayAlert(Messages.MessageTitleVerification, Messages.MessageVerificationUsernameIncorrecte, "Ok");

                }

            }
            else
            {
                Application.Current.MainPage.DisplayAlert(Messages.MessageTitleValidator, validationDesInfos.Errors[0].ErrorMessage, "Ok");
            }


        }




    }
}
