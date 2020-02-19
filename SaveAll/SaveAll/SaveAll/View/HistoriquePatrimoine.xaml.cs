using System;
using System.Collections.Generic;
using SaveAll.Model;
using SaveAll.ViewModel.ViewModelPatrimoine;
using Xamarin.Forms;

namespace SaveAll.View
{
    public partial class HistoriquePatrimoine : ContentPage
    {
        protected ListPatrimoineViewModel ViewModel => BindingContext as ListPatrimoineViewModel;

        public HistoriquePatrimoine()
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
            ViewModel.SelectedItem = e.SelectedItem as Patrimoine;
        }

        protected override void OnAppearing()
        {
            BindingContext = new ListPatrimoineViewModel(Navigation);
        }

    }
}
