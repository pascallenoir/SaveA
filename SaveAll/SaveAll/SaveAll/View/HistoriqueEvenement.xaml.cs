using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SaveAll.ViewModel.ViewModelEvenement;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoriqueEvenement : ContentPage
    {
        public HistoriqueEvenement()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            this.BindingContext = new ListEvementViewModel(Navigation);
        }

       
    }
}
