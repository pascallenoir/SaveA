using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Interfaces;
using SaveAll.Model;
using SaveAll.Validator;
using SaveAll.View;
using SaveAll.ViewModel.ViewModelParametres;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelDocument
{
    public class EnregistrementDocumentViewModel : BaseDocumentViewModel
    {
        public ICommand EnregistrementCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }
        public ICommand AjouterDocument { get; private set; }

        


        public EnregistrementDocumentViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _document = new Document();
            TypeDocument = new TypeDocument();
            _documentValidator = new DocumentValidator();
            baseParametresViewModel = new BaseParametresViewModel();
            _localNotificationService = DependencyService.Get<ILocalNotificationService>();

            AjouterDocument = new Command(async () => await AjoutDocDuDocument());

            EnregistrementCommand = new Command(async () => await EnregistrementDuDocument());
            AnnulerCommand = new Command(async () => await Annuler());

            FetchTypeDocument();

        }


        /// <summary>
        /// Afficher la liste des type de document dans le picker
        /// </summary>
        /// <returns></returns>

        async Task FetchTypeDocument()
        {
            TypedocumentList = await new DatabaseHelper().TousLesTypesDocumentsAsync();
        }




        private async Task AjoutDocDuDocument()
        {
            try
            {

                var fileData = await CrossFilePicker.Current.PickFile();

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
        /// Enregistrer les documents utilisateur
        /// </summary>
        /// <returns></returns>

        async Task EnregistrementDuDocument()
        {
            var validation = _documentValidator.Validate(_document);

        if (validation.IsValid)
            {

              bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageEnregistrement, Messages.MessageValidation, "Enregistrer", "Annuler") ;

            if (isUserAccept)
            {
                    if (baseParametresViewModel.Notifications == true)
                    {

                        var date = (DateExp.Date.Month.ToString("00") + "-" + DateExp.Date.Day.ToString("00") + "-" + DateExp.Date.Year.ToString());
                        var time = Convert.ToDateTime(HeureExp.ToString()).ToString("HH:mm");
                        var dateTime = date + " " + time;
                        var selectedDateTime = DateTime.ParseExact(dateTime, "MM-dd-yyyy HH:mm", CultureInfo.InvariantCulture);


                        _localNotificationService.LocalNotification("Savall", DescriptionDocument, 0, selectedDateTime);


                        _document.EnregistrerEnBase();

                        var ldoc = new DatabaseHelper().TousLesDocuments().GetAwaiter().GetResult();
                                var doc = ldoc.FindLast(p=>p.nomDocument!= null);


                                if (App.MembreActuel==null)
                                {
                                    App.MembreActuel = App.user;
                                   
                                }
                               
                                App.MembreActuel.AttribuerDocument(doc);

                                await Application.Current.MainPage.DisplayAlert(Messages.MessageSucces, Messages.MessageOk, "OK");


                            await PopupNavigation.Instance.PopAsync();
                                MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");
                    }

                    else
                    {
                        _localNotificationService.Cancel(0);
                        _document.EnregistrerEnBase();
                       

                        var ldoc = new DatabaseHelper().TousLesDocuments().GetAwaiter().GetResult();
                        var doc = ldoc.FindLast(p => p.nomDocument != null);


                        if (App.MembreActuel == null)
                        {
                            App.MembreActuel = App.user;

                        }

                        App.MembreActuel.AttribuerDocument(doc);

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
        /// Annuler la procedure enregistrement
        /// </summary>
        /// <returns></returns>

        async Task Annuler()
        {
            await PopupNavigation.Instance.PopAsync();
        }


        // public string SelectedItemPicker
        // {
        //     get => _typeDocument.SelectedItemPicker;
        //     set
        //     {
        //         var typ = _typedocumentList.FirstOrDefault(p => p.SelectedItemPicker == value);
        //         _document.AffecterTypeDocumentAsync(typ);
        //         NotifyPropertyChanged("SelectedItemPicker");
        //     }
        // }


    }
}
