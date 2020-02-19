using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using MvvmHelpers;
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
        public string NomTypeDocument { get; set; }
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
        void OnTypeDocumentChanged()
        {
            NomTypeDocument = TypeDocument.NomTypeDocument;
            System.Diagnostics.Debug.WriteLine($"*** Called {nameof(OnTypeDocumentChanged)}(). {nameof(TypeDocument)}.{nameof(TypeDocument.NomTypeDocument)}: {TypeDocument.NomTypeDocument}");
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
