using System;
using System.Collections.Generic;
using SaveAll.ViewModel.ViewModelUtilisateur;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgetPasswordPageFinView : ContentPage
    {
       
        public ForgetPasswordPageFinView(int identifiant)
        {
            InitializeComponent();
            BindingContext = new ForgetPasswordQuatreViewModel(Navigation, identifiant);

        }


        void AuClickSurChamps(object sender, EventArgs e)
        {
            Pass.IsPassword = !Pass.IsPassword;
            ConfirmPass.IsPassword = !ConfirmPass.IsPassword;

            if (Pass.IsPassword)
            {
                LabelPassword.Text = "Masquer mot de passe";


            }
            else
            {
                LabelPassword.Text = "Afficher mot de passe";
            }



        }

    }
}
