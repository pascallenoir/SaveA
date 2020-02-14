using SaveAll.ViewModel.ViewModelParametres.ParametresTypesViewModel.TypeDocumentViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTypeDocumentPageView : ContentPage
    {
        public ListTypeDocumentPageView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            this.BindingContext = new ListTypeDocumentViewModel(Navigation);
        }

    }
}