using System;
using System.Collections.Generic;
using SaveAll.ViewModel.ViewModelUtilisateur;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgetPasswordPage2View : ContentPage
    {
        public ForgetPasswordPage2View(int ID)
        {
            InitializeComponent();
            BindingContext = new ForgetPasswordDeuxViewModel(Navigation, ID);

        }



    }
}
