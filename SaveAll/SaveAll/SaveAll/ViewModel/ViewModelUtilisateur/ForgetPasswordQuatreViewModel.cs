using System;
using System.Windows.Input;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelUtilisateur
{
    public class ForgetPasswordQuatreViewModel : BaseUtilisateurViewModel
    {
        public ICommand ReinitialiserCommand { get; private set; }



        public ForgetPasswordQuatreViewModel(INavigation navigation, int selectedMembreID)
        {
            _navigation = navigation;
            _membre = new Membre();
            _validatorPaswordOublie = new ValidatorPaswordOublie();
            _membre.Id = selectedMembreID;


            ReinitialiserCommand = new Command(() => Reinitialisation());

            
        }




        private void Reinitialisation()
        {
            var validationDesInfos = _validatorPaswordOublie.Validate(this);


            if (validationDesInfos.IsValid)
            {

                _membre.Pass = _membre.Pass.EncodeMd5();

                _membre.MisAjourEnBase();

                Application.Current.MainPage.DisplayAlert(Messages.MessageTitle, Messages.MessageAlerteReinitialisation, "OK");

                _navigation.PushAsync(new IdentityCardpage());

            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Desolé", validationDesInfos.Errors[0].ErrorMessage, "Ok");
            }

        }




    }
}
