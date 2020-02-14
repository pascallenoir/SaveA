using System;
using System.Collections.Generic;
using SaveAll.ViewModel.ViewModelUtilisateur;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgetPasswordPage3View : ContentPage
    {
        public ForgetPasswordPage3View()
        {
            InitializeComponent();
            BindingContext = new ForgetPasswordTroisViewModel(Navigation);

        }



    }
}
