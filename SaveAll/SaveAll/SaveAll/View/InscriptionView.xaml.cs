using SaveAll.ViewModel.ViewModelUtilisateur;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InscriptionView : ContentPage
    {
        public InscriptionView()
        {
            InitializeComponent();
            BindingContext = new EnregistrementUtilisateurViewModel(Navigation);
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
