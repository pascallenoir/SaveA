using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Interfaces;
using SaveAll.Model;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelPatrimoine
{
    public class DetailsPatrimoineViewModel : BasePatrimoineViewModel
    {

        public ICommand DeleteCommand { get; private set; }
        public ICommand MiseAjourPageCommand { get; private set; }



        public DetailsPatrimoineViewModel(INavigation navigation, int selectedPatrimoineID)
        {
            _navigation = navigation;
            _patrimoine = new Patrimoine();
            _patrimoine.Id = selectedPatrimoineID;
            _typePatrimoine = new TypePatrimoine
            {
                IdTypePatrimoine = selectedPatrimoineID
            };

            DeleteCommand = new Command(async () => await DeletePatrimoine());

            MiseAjourPageCommand = new Command(async () => await ModificationDesInfos());

            FetchMembreDetailsAsync();

        }


        /// <summary>
        /// Bouton de retour
        /// </summary>
        /// <returns></returns>



        /// <summary>
        /// Mise a jour des informations sur un membre
        /// </summary>
        /// <returns></returns>

        [Obsolete]
        async Task ModificationDesInfos()
        {
            var pr = new MiseAJourPatrimoinePageView(_patrimoine.Id);

            await PopupNavigation.PushAsync(pr);

        }

        /// <summary>
        /// Afficher les informations sur la page
        /// </summary>

        async Task FetchMembreDetailsAsync()
        {
           
            _patrimoine = await new DatabaseHelper().PatrimoineById(_patrimoine.Id);
            _typePatrimoine = await new DatabaseHelper().TypePatrimoineById(_typePatrimoine.IdTypePatrimoine);
            // convert string to stream
            byte[] byteArray = Encoding.ASCII.GetBytes(_patrimoine.PreviewPath);
            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            MemoryStream stream = new MemoryStream(byteArray,0, byteArray.Length);
        }



        /// <summary>
        /// Supprimer un membre
        /// </summary>
        /// <returns></returns>

        async Task DeletePatrimoine()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionelement, "Supprimer", "Annuler");
            if (isUserAccept)
            {
                await new DatabaseHelper().SupprimerPatrimoineById(_patrimoine.Id);

                 await _navigation.PopAsync();
            }
        }
    }
}
