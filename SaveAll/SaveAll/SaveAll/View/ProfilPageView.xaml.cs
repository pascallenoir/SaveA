using System;
using System.ComponentModel.Design;
using System.IO;
using Plugin.Media;
using SaveAll.Controls;
using SaveAll.ViewModel.ViewModelUtilisateur;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilPageView : ContentPage
    {
        public ProfilPageView()
        {
            InitializeComponent();

            BindingContext = new ProfilViewModelUtilisateur(Navigation) ;
           

        }

        void AfficheInfoUtilisateur(object sender, EventArgs e)
        {
            Etatcivil.IsVisible = !Etatcivil.IsVisible;

            if (Etatcivil.IsVisible)
            {

                ImageButtonEtatcivil.Source = "ic_control_point.png";

            }
            else
            {
                ImageButtonEtatcivil.Source = "ic_remove_circle_outline.png";
            }

        }


         void DefilSecuriteCommand(object sender, EventArgs e)
        {
            Securite.IsVisible = !Securite.IsVisible;

            if (Securite.IsVisible)
            {
                ImageButtonSecurite.Source = "ic_control_point.png";

            }
            else
            {
                ImageButtonSecurite.Source = "ic_remove_circle_outline.png";

            }

        }


        void EditionTool(object sender, EventArgs e)
        {
            ProfilFiche.IsEnabled = !ProfilFiche.IsEnabled;

            if (ProfilFiche.IsEnabled)
            {
                toolbar.IconImageSource = "ic_lock_open.png";
                ProfilFiche.BackgroundColor = Color.Transparent;

            }
            else
            {
                toolbar.IconImageSource = "ic_lock.png";
                ProfilFiche.BackgroundColor = Color.LightGray;

            }


        }

        private void FlexButton_Telephone(object sender, EventArgs e)
        {
            SecondNumeroTelephone.IsVisible = !SecondNumeroTelephone.IsVisible;

            if (SecondNumeroTelephone.IsVisible)
            {
                AjoutButton.Icon = "delete.png";

            }
            else
            {
                AjoutButton.Icon = "ic_add_circle";
               
            }

        }

        private void FlexButton_Address(object sender, EventArgs e)
        {
            AdresseSecondaire.IsVisible = !AdresseSecondaire.IsVisible;

            if (AdresseSecondaire.IsVisible)
            {
                AjoutButtonAddress.Icon = "delete.png";

            }
            else
            {
                AjoutButtonAddress.Icon = "ic_add_circle";

            }

        }

    }
}
