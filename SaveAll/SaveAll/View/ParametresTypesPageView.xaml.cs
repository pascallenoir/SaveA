using SaveAll.ViewModel.ViewModelParametres.ParametresTypesViewModel;
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
    public partial class ParametresTypesPageView : ContentPage
    {
        public ParametresTypesPageView()
        {
            InitializeComponent();
            BindingContext = new ParametresTypesViewModel(Navigation);

        }
    }
}