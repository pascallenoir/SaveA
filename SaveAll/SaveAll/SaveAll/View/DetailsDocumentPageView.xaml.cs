using System;
using System.Collections.Generic;
using System.IO;
using SaveAll.ViewModel.ViewModelDocument;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsDocumentPageView : ContentPage
    {
        public DetailsDocumentPageView(int documentID)
        {
            InitializeComponent();
            this.BindingContext = new DetailsDocumentViewModel(Navigation, documentID);

        }


      
    }
}
