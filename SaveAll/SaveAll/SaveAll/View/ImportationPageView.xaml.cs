using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImportationPageView : ContentPage
    {
        public ImportationPageView()
        {
            InitializeComponent();
        }

        private void ConnexionClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new InscriptionView());
        }

    }
}
