using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.Validator;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelMembre
{
    public class DetailMembreViewModel : BaseMembreViewModel
    {

        public ICommand DeleteCommand { get; private set; }
        public ICommand MiseAjourPageCommand { get; private set; }



        public DetailMembreViewModel(INavigation navigation, int selectedMembreID)
        {
            _navigation = navigation;
            _membre = new Membre();
            _membre.Id = selectedMembreID;
            _typeMembre = new TypeMembre
            {
                IdTypeMembre = selectedMembreID
            };


            DeleteCommand = new Command(async () => await DeleteMembre());

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
            var pr = new MiseAJourMembrePageView(_membre.Id);
            
            await PopupNavigation.PushAsync(pr);

        }

        /// <summary>
        /// Afficher les informations sur la page
        /// </summary>

        void FetchMembreDetailsAsync()
        {
            _membre = new DatabaseHelper().MembreById(_membre.Id);
            
        }

        /// <summary>
        /// Supprimer un membre
        /// </summary>
        /// <returns></returns>

        async Task DeleteMembre()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionelement, "Supprimer", "Annuler");
            if (isUserAccept)
            {
                await new DatabaseHelper().SupprimerMembreAsync(_membre.Id);

                await _navigation.PopAsync();
            }
        }
    }
}


