using System;
using System.Collections.Generic;
using SaveAll.ViewModel.ViewModelUtilisateur;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgetPasswordPageView : ContentPage
    {
        public ForgetPasswordPageView()
        {
            InitializeComponent();
            BindingContext = new ForgetPasswordUnViewModel(Navigation);
        }

       

    }
}
