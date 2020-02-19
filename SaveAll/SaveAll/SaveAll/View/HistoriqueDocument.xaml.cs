using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SaveAll.ViewModel.ViewModelDocument;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoriqueDocument : ContentPage
    {
        protected ListDocumentViewModel ViewModel => BindingContext as ListDocumentViewModel;

        public HistoriqueDocument()
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
            BindingContext = new ListDocumentViewModel(Navigation);
        }
    }
}