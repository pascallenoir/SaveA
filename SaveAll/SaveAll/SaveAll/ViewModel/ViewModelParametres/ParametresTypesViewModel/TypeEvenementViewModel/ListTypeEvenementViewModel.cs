using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelParametres.ParametresTypesViewModel.TypeDocumentViewModel
{
    class ListTypeEvenementViewModel : BaseTypeViewModel
    {


        public ICommand AjouterTypeCommand { get; private set; }
        public ICommand DeleteAllCommand { get; private set; }



        public ListTypeEvenementViewModel(INavigation navigation)
        {
            _navigation = navigation;


            DeleteAllCommand = new Command(async () => await DeleteAllDocuments());
            AjouterTypeCommand = new Command(async () => await AjouterNouveauTypeCommand());

             MessagingCenter.Subscribe<App>((App)Application.Current, "ActualiserListe", (sender) =>
             {
                 FetchtypeEvenement();
             });


            FetchtypeEvenement();


        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        private Task DeleteAllDocuments()
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Affiicher la liste des types evenement 
        /// </summary>
        /// <returns></returns>

        async Task FetchtypeEvenement()
        {
            TypeEvenementList.Clear();
            TypeEvenementList.AddRange(await new DatabaseHelper().TousLesTypesEvenementsAsync());            // fonctionnalite pour recuperer tous les enregistrements

        }


        /// <summary>
        /// Ajouter un nouveau document
        /// </summary>
        /// <returns></returns>

        [Obsolete]
        async Task AjouterNouveauTypeCommand()
        {
            var pr = new AjoutTypeEvenementPageView();

            await PopupNavigation.PushAsync(pr);

        }
    }
}