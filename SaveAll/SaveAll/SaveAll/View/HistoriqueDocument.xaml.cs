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

        public HistoriqueDocument()
        {
            InitializeComponent();
        }

        
        protected override void OnAppearing()
        {
            
            this.BindingContext = new ListDocumentViewModel(Navigation);
        }

       
    }
}