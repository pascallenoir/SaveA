using SaveAll.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelParametres
{
    public class ParametresGenerauxViewModel : BaseParametresViewModel
    {

            public ICommand ActiviteNotificationsCommand { get; private set; }
            public ICommand ActiviteSauvegardeCommand { get; private set; }
            public ICommand ActiviteTypeCommand { get; private set; }
            public ICommand ActiviteAproposCommand { get; private set; }

        public ParametresGenerauxViewModel(INavigation navigation)
            {
                _navigation = navigation;

            ActiviteNotificationsCommand = new Command(async () => await ActiviteNotifications());

            ActiviteSauvegardeCommand = new Command(async () => await ActiviteSauvegarde());

            ActiviteTypeCommand = new Command(async () => await ActiviteType());

            ActiviteAproposCommand = new Command(async () => await ActiviteApropos());

        }


        async Task ActiviteApropos()
        {
            await _navigation.PushAsync(new AProposPageView());
        }

        async Task ActiviteType()
        {
            await _navigation.PushAsync(new ParametresTypesPageView()); 
        }

        async Task ActiviteSauvegarde()
        {
            await _navigation.PushAsync(new ParametresSauvegardePageView());
        }

        async Task ActiviteNotifications()
        {
           await _navigation.PushAsync(new NotificationsPageView());
        }
    }
}
