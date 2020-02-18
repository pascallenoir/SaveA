using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Interfaces;
using SaveAll.Model;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelPatrimoine
{
    public class MiseAjourPatrimoineViewModel : BasePatrimoineViewModel
    {

        public ICommand DeleteCommand { get; private set; }
        public ICommand EnregistrementCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }



        public MiseAjourPatrimoineViewModel(INavigation navigation, int selectedPatrimoineID)
        {
            _navigation = navigation;
            _patrimoine = new Patrimoine();
            _patrimoine.Id = selectedPatrimoineID;
            _typePatrimoine = new TypePatrimoine
            {
                IdTypePatrimoine = selectedPatrimoineID
            };

            DeleteCommand = new Command(async () => await DeletePatrimoine());
            EnregistrementCommand = new Command(async () => await ModificationDesInfos());
            AnnulerCommand = new Command(async () => await retourDePage());


            FetchPatrimoineDetails();
            FetchTypePatrimoine();

        }

  

        /// <summary>
        /// Bouton de retour
        /// </summary>
        /// <returns></returns>
        /// 
        async Task retourDePage()
        {
            await PopupNavigation.Instance.PopAsync();

        }

     

        /// <summary>
        /// Mise a jour des information pour un bien
        /// </summary>
        /// <returns></returns>

        async Task ModificationDesInfos()
        {

           
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageEnregistrement, Messages.MessageValidation, "Enregistrer", "Annuler");

                if (isUserAccept)
                {
                    _patrimoine.MisAjourEnBase();

                    await Application.Current.MainPage.DisplayAlert(Messages.MessageSucces, Messages.MessageOk, "OK");
                    await PopupNavigation.Instance.PopAsync();
                    MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");

            }
            
         
        }


        /// <summary>
        /// Afficher les informations du bien sur la page
        /// </summary>
        /// <returns></returns>

        async Task FetchPatrimoineDetails()
        {
            _patrimoine = await new DatabaseHelper().PatrimoineById(_patrimoine.Id);
            _typePatrimoine = await new DatabaseHelper().TypePatrimoineById(_typePatrimoine.IdTypePatrimoine);

        }


        /// <summary>
        /// Afficher la liste de tous les types patrimoines
        /// </summary>
        /// <returns></returns>
        async Task FetchTypePatrimoine()
        {
            TypePatrimoineList = await new DatabaseHelper().TousLesTypesPatrimoines();
        }



        /// <summary>
        /// Supprimer un bien
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