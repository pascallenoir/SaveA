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
    public partial class ListTypeEvenementPageView : ContentPage
    {
        public ListTypeEvenementPageView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            this.BindingContext = new ListTypeEvenementViewModel(Navigation);
        }

    }
}