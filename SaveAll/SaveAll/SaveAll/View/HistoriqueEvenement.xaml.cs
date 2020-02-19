using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SaveAll.Model;
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

            ListView.ItemSelected += ListView_ItemSelected;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SearchCommand.Execute(e.NewTextValue);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectedItem = e.SelectedItem as Evenement;
        }

        protected override void OnAppearing()
        {
            BindingContext = new ListEvementViewModel(Navigation);
        }
    }
}
