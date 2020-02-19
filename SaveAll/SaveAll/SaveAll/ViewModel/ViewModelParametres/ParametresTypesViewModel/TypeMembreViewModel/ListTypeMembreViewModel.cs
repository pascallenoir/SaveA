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
    class ListTypeMembreViewModel : BaseTypeViewModel
    {

        public ICommand AjouterTypeCommand { get; private set; }
        public ICommand DeleteAllCommand { get; private set; }



        public ListTypeMembreViewModel(INavigation navigation)
        {
            _navigation = navigation;


            DeleteAllCommand = new Command(async () => await DeleteAllDocuments());
            AjouterTypeCommand = new Command(async () => await AjouterNouveauTypeCommand());

             MessagingCenter.Subscribe<App>((App)Application.Current, "ActualiserListe", (sender) =>
             {
                 FetchtypeMembre();
             });


            FetchtypeMembre();


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

        async Task FetchtypeMembre()
        {
            TypeMembreList.Clear();
            TypeMembreList.AddRange(await new DatabaseHelper().TousLesTypesMembres());            // fonctionnalite pour recuperer tous les enregistrements

        }


        /// <summary>
        /// Ajouter un nouveau document
        /// </summary>
        /// <returns></returns>

        [Obsolete]
        async Task AjouterNouveauTypeCommand()
        {
            var pr = new AjoutTypeMembrePageView();

            await PopupNavigation.PushAsync(pr);

        }
    }
}