using System;
using System.Collections.Generic;
using SaveAll.Interfaces;
using SaveAll.ViewModel.ViewModelPatrimoine;
using Xamarin.Forms;

namespace SaveAll.View
{
    public partial class DetailsPatrimoinePageView : ContentPage
    {
       

        public DetailsPatrimoinePageView(int PatrimoineID)
        {
            InitializeComponent();
            this.BindingContext = new DetailsPatrimoineViewModel(Navigation, PatrimoineID);
        }
    }
}
