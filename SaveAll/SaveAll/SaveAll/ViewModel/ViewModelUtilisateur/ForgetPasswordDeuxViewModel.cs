using System;
using System.Windows.Input;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelUtilisateur
{
    public class ForgetPasswordDeuxViewModel : BaseUtilisateurViewModel
    {
        public ICommand ValidationCommand { get; private set; }
        


        public ForgetPasswordDeuxViewModel(INavigation navigation, int selectedMembreID)
        {
            _navigation = navigation;
            _membre = new Membre();
            _validatorQuestionSecuriteUn = new ValidatorQuestionSecuriteUN();
            _membre.Id = selectedMembreID;


            ValidationCommand = new Command(() => Validation());

            FetchInfosquestion();
        }


        /// <summary>
        ///  Recuperer la question de securite
        /// </summary>


        private void FetchInfosquestion()
        {

            _membre = new DatabaseHelper().MembreById();
            _membre.Reponse = string.Empty;
        }



        /// <summary>
        /// Valider reponse untilisateur
        /// </summary>

        private void Validation()
        {
            var validationDesInfos = _validatorQuestionSecuriteUn.Validate(_membre);


            if (validationDesInfos.IsValid)
            {
                if (_membre.ReponseIsValid())
                {

                    Application.Current.MainPage.DisplayAlert(Messages.MessageTitleVerification, Messages.MessageVerificationReponse, "Ok");

                    _navigation.PushAsync(new ForgetPasswordPageFinView(_membre.Id));
                    

                }
                else
                {
                    Application.Current.MainPage.DisplayAlert(Messages.MessageTitleVerification, Messages.MessageVerificationReponseIncorrecte, "Ok");

                }

            }
            else
            {
                Application.Current.MainPage.DisplayAlert(Messages.MessageTitleValidator, validationDesInfos.Errors[0].ErrorMessage, "Ok");
            }

        }

       


    }
}
