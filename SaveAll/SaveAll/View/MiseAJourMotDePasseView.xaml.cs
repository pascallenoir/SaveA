using System;
using System.Collections.Generic;
using SaveAll.Model;
using SaveAll.ViewModel.ViewModelUtilisateur;
using Xamarin.Forms;

namespace SaveAll.View
{
    public partial class MiseAJourMotDePasseView : ContentPage
    {
        public MiseAJourMotDePasseView(int membreId)
        {
            InitializeComponent();
            BindingContext = new MiseAJourMotDePasseViewModel(Navigation, membreId);

        }


        void AuClickSurChamps(object sender, EventArgs e)
        {
            PassActuel.IsPassword = !PassActuel.IsPassword;
            NewPass.IsPassword = !NewPass.IsPassword;
            ConfirmNewPass.IsPassword = !ConfirmNewPass.IsPassword;

            if (PassActuel.IsPassword)
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
