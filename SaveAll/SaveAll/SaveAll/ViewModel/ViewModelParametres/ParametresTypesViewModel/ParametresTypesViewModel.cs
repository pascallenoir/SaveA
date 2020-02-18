using SaveAll.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelParametres.ParametresTypesViewModel
{
    class ParametresTypesViewModel : BaseParametresViewModel
    {
        public ICommand ListEvenementCommand { get; private set; }
        public ICommand ListDocumentCommand { get; private set; }
        public ICommand ListMembreCommand { get; private set; }
        public ICommand ListPatrimoineCommand { get; private set; }


        public ParametresTypesViewModel(INavigation navigation)
        {
            _navigation = navigation;

            ListEvenementCommand = new Command(async () => await ListEvenement());

            ListDocumentCommand = new Command(async () => await ListDocument());

            ListMembreCommand = new Command(async () => await ListMembre());

            ListPatrimoineCommand = new Command(async () => await ListPatrimoine());

        }

        async Task ListEvenement()
        {
            await _navigation.PushAsync(new ListTypeEvenementPageView());
        }

        async Task ListDocument()
        {
            await _navigation.PushAsync(new ListTypeDocumentPageView());
        }

        async Task ListMembre()
        {
            await _navigation.PushAsync(new ListTypeMembrePageView());
        }

        async Task ListPatrimoine()
        {
            await _navigation.PushAsync(new ListTypePatrimoinePageView());
        }
    }
}
