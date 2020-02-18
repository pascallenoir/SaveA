using System;
using System.Collections.Generic;
using SaveAll.ViewModel.ViewModelUtilisateur;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdentityCardpage : ContentPage
    {

        bool isTaskRunning;
        

        public IdentityCardpage()
        {
            InitializeComponent();
            BindingContext = new LoginUtilisateurViewModel(Navigation);
            defaultActivityIndicator.IsVisible = false;
        }


        void OnButtonClicked(object sender, EventArgs e)
        {
            defaultActivityIndicator.IsVisible = true;
            isTaskRunning = true;
            UpdateUiState();
        }

        void UpdateUiState()
        {
            defaultActivityIndicator.IsRunning = isTaskRunning;

        }

        void AuClickSurChamps(object sender, EventArgs e)
        {   
            PasswordAffiche.IsPassword = !PasswordAffiche.IsPassword;

            if (PasswordAffiche.IsPassword == true)
            {
                LabelPassword.Text = "Afficher mot de passe";

            }
            else
            {
                LabelPassword.Text = "Masquer mot de passe";

            }

        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}