
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Interfaces;
using SaveAll.Model;
using SaveAll.Validator;
using SaveAll.View;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelDocument
{
    public class DetailsDocumentViewModel : BaseDocumentViewModel
    {

        public ICommand DeleteCommand { get; private set; }
        public ICommand MiseAjourPageCommand { get; private set; }
        public ICommand SelectLienCommand { get; private set; }



        public DetailsDocumentViewModel(INavigation navigation, int selectedDocumentID)
        {
            _navigation = navigation;
            _document = new Document();
            _document.Id = selectedDocumentID;

            TypeDocument = new TypeDocument
            {
                IdTypeDocument = selectedDocumentID
            };

            SelectLienCommand = new Command(() => PickAndShowFile());
            DeleteCommand = new Command(async () => await DeleteDocument());

            MiseAjourPageCommand = new Command(async () => await ModificationDesInfos());

            FetchDocumentDetailsAsync();

           

        }



        public void PickAndShowFile()
        {

            var url = _document.NomduFichier;
            var lien = _document.AccesFichier;
           // Launcher.OpenAsync(new Uri("file://" + url));


           var dependency = DependencyService.Get<ILocalFileProvider>();
           
           if (dependency == null)
           {
               Application.Current.MainPage.DisplayAlert("Erreur PDF", "aucun outils trouvés", "OK");
           
               return;
           }
           else
           {
           
               Task.Run(() => dependency.OpenFile(lien, url));
           
           }


        }



        // DependencyService.Get<ILocalFileProvider>().OpenFile(NomduFichier);

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
            var pr = new MiseAjourDocumentPageView(_document.Id);

            await PopupNavigation.PushAsync(pr);

        }

        /// <summary>
        /// Afficher les informations sur la page
        /// </summary>

        async Task FetchDocumentDetailsAsync()
        {

            Stream stream = new MemoryStream();

            _document.Fichier = StreamToByteArray(stream);
            _document = await new DatabaseHelper().DocumentByIdAsync(_document.Id);
            TypeDocument = await new DatabaseHelper().TypeDocumentByIdAsync(_document.IdTypeDoc.Value);
        }


        public static byte[] StreamToByteArray(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Supprimer un membre
        /// </summary>
        /// <returns></returns>

        async Task DeleteDocument()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionelement, "Supprimer", "Annuler");
            if (isUserAccept)
            {
                await new DatabaseHelper().SupprimerDocumentsAsync(_document.Id);

                await _navigation.PopAsync();
            }
        }
    }
}


