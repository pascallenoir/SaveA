using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelDocument
{
    public class ListDocumentViewModel : BaseDocumentViewModel
    {

        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllCommand { get; private set; }
        public ICommand AjouterCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }


        public ListDocumentViewModel(INavigation navigation)
        {
            _navigation = navigation;

          
            DeleteAllCommand = new Command(async () => await DeleteAllDocuments());
            AjouterCommand = new Command(async () => await AddNewDocumentSecond());

            MessagingCenter.Subscribe<App>((App)Application.Current, "ActualiserListe", (sender) =>
            {
                FetchDocumentsAsync();
            });


            FetchDocumentsAsync();

            
        }

       

        /// <summary>
        /// Afiicher la liste des documents 
        /// </summary>
        /// <returns></returns>

        async Task FetchDocumentsAsync()
        {

            DocumentList = await App.MembreActuel.SesDocuments();            // fonctionnalite pour recuperer tous les enregistrements

            
        }


        /// <summary>
        /// Ajouter un nouveau document
        /// </summary>
        /// <returns></returns>

        [Obsolete]
        async Task AddNewDocumentSecond()
        {
            var pr = new NouveauDocumentPageView();
          
            await PopupNavigation.PushAsync(pr);
            
        }


        /// <summary>
        /// Supprimer tous les enregistrements
        /// </summary>
        /// <returns></returns>
        /// 
        async Task DeleteAllDocuments()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionTotal, "Supprimer", "Annuler");
            if (isUserAccept)
            {
                await new DatabaseHelper().SupprimerTousLesDocumentsAsync();

            }
        }

        /// <summary>
        /// Afiicher les details pour un enregistrement
        /// </summary>
        /// <param name="selectedDocumentID"></param>
        /// <returns></returns>

      [Obsolete]
     async Task ShowDocumentsDetails(int selectedDocumentID)
     {
         var pr = new DetailsDocumentPageView(selectedDocumentID);
        
         await _navigation.PushAsync(pr);
     }
    
     Document _selectedItem;
     public Document SelectedItem
     {
         get => _selectedItem;
         set
         {
             if (value != null)
             {
                 _selectedItem = value;
                 NotifyPropertyChanged("SelectedItem");
                 ShowDocumentsDetails(value.Id);
             }
         }
     }
    }
}