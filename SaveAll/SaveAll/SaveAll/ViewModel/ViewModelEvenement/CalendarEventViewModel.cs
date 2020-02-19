using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelEvenement
{
    public class CalendarEventViewModel : BaseEvenementViewModel
    {

        public CalendarEventViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _evenement = new Evenement();


            FetchEvenementList();



        }

        async Task FetchEvenementList()
        {
            CalendarInlineEvents = await App.MembreActuel.SesEvenementsAsync();
        }


        /// <summary>
        /// Afficher les details pour un enregistrement
        /// </summary>
        /// <param name="selectedEvenementID"></param>
        /// <returns></returns>

        [Obsolete]
        async Task ShowEvenementsDetails(int selectedEvenementID)
        {
            var pr = new DetailsEvenementPageView(selectedEvenementID);

            await _navigation.PushAsync(pr);
        }

        public Evenement SelectedItem { get; set; }

        void OnSelectedItemChanged()
        {
            ShowEvenementsDetails(SelectedItem.id);
        }
    }
}
