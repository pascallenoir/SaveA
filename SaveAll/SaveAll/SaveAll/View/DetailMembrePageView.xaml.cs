using System;
using System.Collections.Generic;
using SaveAll.ViewModel.ViewModelMembre;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailMembrePageView : ContentPage
    {
        public DetailMembrePageView(int membreID)
        {
            InitializeComponent();
            this.BindingContext = new DetailMembreViewModel(Navigation, membreID);
        }
    }
}
