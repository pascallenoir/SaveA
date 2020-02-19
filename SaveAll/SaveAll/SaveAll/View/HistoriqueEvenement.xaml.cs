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
        protected ListEvementViewModel ViewModel => BindingContext as ListEvementViewModel;

        public HistoriqueEvenement()
        {
            InitializeComponent();

            SearchBar.TextChanged += SearchBar_TextChanged;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SearchCommand.Execute(e.NewTextValue);
        }

        protected override void OnAppearing()
        {
            BindingContext = new ListEvementViewModel(Navigation);
        }
    }
}
