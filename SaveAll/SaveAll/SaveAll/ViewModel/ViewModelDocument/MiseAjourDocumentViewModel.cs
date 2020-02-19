using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Interfaces;
using SaveAll.Model;
using SaveAll.Validator;
using SaveAll.ViewModel.ViewModelParametres;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelDocument
{
    public class MiseAjourDocumentViewModel : BaseDocumentViewModel
    {

        public ICommand DeleteDocumentCommand { get; private set; }
        public ICommand JoindreDocumentCommand { get; private set; }
        public ICommand ModificationCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }



        public MiseAjourDocumentViewModel(INavigation navigation, int selectedDocumentID)
        {
            _navigation = navigation;
            _documentValidator = new DocumentValidator();
            _document = new Document();
            _document.Id = selectedDocumentID;

            TypeDocument = new TypeDocument
            {
                IdTypeDocument = selectedDocumentID
            };
            baseParametresViewModel = new BaseParametresViewModel();
            _localNotificationService = DependencyService.Get<ILocalNotificationService>();

            DeleteDocumentCommand = new Command(async () => await DeleteDocument());
            JoindreDocumentCommand = new Command(async () => await JoindreDocument());
            ModificationCommand = new Command(async () => await ModificationDesInfos());
            AnnulerCommand = new Command(async () => await retourDePage());

            FetchDocumentDetailsAsync();

            FetchTypeDocument();


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
        /// Ajouter un fichier pdf ou image
        /// </summary>
        /// <returns></returns>

        private async Task JoindreDocument()
        {
            try
            {


                FileData fileData = new FileData();
                fileData = await CrossFilePicker.Current.PickFile();

                if (fileData != null)
                {

                    NomduFichier = fileData.FileName;
                    AccesFichier = fileData.FilePath;
                    Fichier = fileData.DataArray;
                }
            }
            catch (Exception ex)
            {
                NomduFichier = ex.ToString();

            }
        }


        /// <summary>
        /// Mise a jour des information pour un document
        /// </summary>
        /// <returns></returns>

        async Task ModificationDesInfos()
        {
            var validation = _documentValidator.Validate(_document);

            if (validation.IsValid)
            {

                bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageEnregistrement, Messages.MessageValidation, "Enregistrer", "Annuler");

                if (isUserAccept)
                {

                    if (baseParametresViewModel.Notifications == true)
                    {

                        var date = (DateExp.Date.Month.ToString("00") + "-" + DateExp.Date.Day.ToString("00") + "-" + DateExp.Date.Year.ToString());
                        var time = Convert.ToDateTime(HeureExp.ToString()).ToString("HH:mm");
                        var dateTime = date + " " + time;
                        var selectedDateTime = DateTime.ParseExact(dateTime, "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture);


                        _localNotificationService.LocalNotification("Savall", DescriptionDocument, 0, selectedDateTime);


                        _document.MisAjourEnBase();
                        await Application.Current.MainPage.DisplayAlert(Messages.MessageSucces, Messages.MessageOk, "OK");
                        await PopupNavigation.Instance.PopAsync();
                        MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");

                    }

                    else
                    {
                        _localNotificationService.Cancel(0);

                        _document.MisAjourEnBase();
                        await Application.Current.MainPage.DisplayAlert(Messages.MessageSucces, Messages.MessageOk, "OK");
                        await PopupNavigation.Instance.PopAsync();
                        MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");

                    }
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(Messages.MessageTitleError, validation.Errors[0].ErrorMessage, "Ok");
            }

        }


        /// <summary>
        /// Afficher les informations du document sur la page
        /// </summary>
        /// <returns></returns>

        async Task FetchDocumentDetailsAsync()
        {
            _document = await new DatabaseHelper().DocumentByIdAsync(_document.Id);
            TypeDocument = await new DatabaseHelper().TypeDocumentByIdAsync(_document.IdTypeDoc.Value);

        }



        /// <summary>
        /// Afficher la liste des type de document dans le picker
        /// </summary>
        /// <returns></returns>

        async Task FetchTypeDocument()
        {
            TypedocumentList = await new DatabaseHelper().TousLesTypesDocumentsAsync();
        }


        /// <summary>
        /// Supprimer un document
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