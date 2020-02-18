using System;
using System.Collections.Generic;
using SaveAll.ViewModel.ViewModelPatrimoine;
using Xamarin.Forms;

namespace SaveAll.View
{
    public partial class HistoriquePatrimoine : ContentPage
    {
        public HistoriquePatrimoine()
        {
            InitializeComponent();
        }
         
        protected override void OnAppearing()
        {

            this.BindingContext = new ListPatrimoineViewModel(Navigation);
        }

    }
}
