using SaveAll.ViewModel.ViewModelParametres;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SaveAll.View
{
    public partial class ParametresPageView : ContentPage
    {
        public ParametresPageView()
        {
            InitializeComponent();
            BindingContext = new ParametresGenerauxViewModel(Navigation);
        }
    }
}
