using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SaveAll.Model;
using SaveAll.ViewModel.ViewModelMembre;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoriqueMembre : ContentPage
    {
        protected ListMembreViewModel ViewModel => BindingContext as ListMembreViewModel;

        public HistoriqueMembre()
        {
            InitializeComponent();

            SearchBar.TextChanged += SearchBar_TextChanged;
        }

        private void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectedItem = e.SelectedItem as Membre;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SearchCommand.Execute(e.NewTextValue);
        }

        protected override void OnAppearing()
        {
            BindingContext = new ListMembreViewModel(Navigation);
        }
    }
}
