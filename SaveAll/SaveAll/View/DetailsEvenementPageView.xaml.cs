using System;
using System.Collections.Generic;
using SaveAll.ViewModel.ViewModelEvenement;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsEvenementPageView : ContentPage
    {
        public DetailsEvenementPageView(int EvenementID)
        {
            InitializeComponent();
            this.BindingContext = new DetailsEvenementViewModel(Navigation, EvenementID);

        }
    }
}
