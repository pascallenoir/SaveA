using System;
using System.Collections.Generic;
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
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SearchCommand.Execute(e.NewTextValue);
        }

        protected override void OnAppearing()
        {

            BindingContext = new ListPatrimoineViewModel(Navigation);
        }

    }
}
