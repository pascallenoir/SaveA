using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using MvvmHelpers;
using PropertyChanged;
using SaveAll.FrameworkMVVM;
using SaveAll.Interfaces;
using SaveAll.Model;
using SaveAll.ViewModel.ViewModelParametres;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelDocument
{
    public class BaseDocumentViewModel : ViewModelDeBase
    {
        public Document _document;
        public TypeDocument TypeDocument { get; set; }
        public BaseParametresViewModel baseParametresViewModel;
        public ILocalNotificationService _localNotificationService;
        public INavigation _navigation;
        public IValidator _documentValidator;

        public string nomDocument { get; set; }
        public List<TypeDocument> TypedocumentList { get; set; }

        // You can use property attributes from PropertyChanged.Fody to chain together properties.
        // In this case, I'm telling NomTypeDocument that it should fire a Propertychanged event each time that TypeDocument changes, and that it should get its value from TypeDocument.NomTypeDocument.
        [DependsOn(nameof(TypeDocument))] 
        public string NomTypeDocument => TypeDocument.NomTypeDocument;

        public string Code { get; set; }
        public bool? Periodicite { get; set; }
        public string DescriptionDocument { get; set; }
        public DateTime DateEts { get; set; }
        public DateTime DateExp { get; set; }
        public TimeSpan HeureExp { get; set; }
        public string Organisme { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Fichier { get; set; }
        public string NomduFichier { get; set; }
        public string AccesFichier { get; set; }
        public string SearchText { get; set; }
        public ObservableRangeCollection<Document> DocumentList { get; set; } = new ObservableRangeCollection<Document>();
        public ObservableRangeCollection<Document> SearchDocumentList { get; set; } = new ObservableRangeCollection<Document>();

        public MvvmHelpers.Commands.Command<string> SearchCommand { get; set; }

        public BaseDocumentViewModel()
        {
            SearchCommand = new MvvmHelpers.Commands.Command<string>(searchText => DoSearchCommand(searchText));

            DocumentList.CollectionChanged += DocumentList_CollectionChanged;
        }

        // Because we're using PropertyChanged.Fody, we can use the "void On[MyProperty]Changed()" convention in order to catch PropertyChanged events and act upon them.
        // I commented this out in order to demonstrate the [DependsOn()] attribute above.
        // Either of the two strategies work well. Using attributes is syntactically compact and simple, whereas On[MyProperty]Changed is robust and extendable.
        // Excercise caution when using the two different strategies in tandem.

        //void OnTypeDocumentChanged()
        //{
        //    NomTypeDocument = TypeDocument.NomTypeDocument;
        //    System.Diagnostics.Debug.WriteLine($"*** Called {nameof(OnTypeDocumentChanged)}(). {nameof(TypeDocument)}.{nameof(TypeDocument.NomTypeDocument)}: {TypeDocument.NomTypeDocument}");
        //}

        // This method will not get called if [DependsOn(nameof(TypeDocument))] is applied to the NomTypeDocument property.
        // But if you removed [DependsOn(nameof(TypeDocument))] from NomTypeDocument property and made it a get/set, this method would fire.
        void OnNomTypeDocumentChanged()
        {
            System.Diagnostics.Debug.WriteLine($"{nameof(OnNomTypeDocumentChanged)}(): NomTypeDocument = {NomTypeDocument}");
        }

        private void DocumentList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SearchDocumentList.Clear();
            SearchDocumentList.AddRange(DocumentList);
        }

        void DoSearchCommand(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                SearchDocumentList.Clear();
                SearchDocumentList.AddRange(DocumentList);
            }
            else
            {
                SearchDocumentList.Clear();
                SearchDocumentList.AddRange(DocumentList.Where(x => x.nomDocument.Contains(searchText)));
            }
        }
    }
}
