using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FluentValidation;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using SaveAll.FrameworkMVVM;
using SaveAll.Helpers;
using SaveAll.Interfaces;
using SaveAll.Model;
using SaveAll.ViewModel.ViewModelParametres;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelDocument
{
    public class BaseDocumentViewModel : ViewModelDeBase
    {
        public Document _document;
        public TypeDocument _typeDocument;
        public BaseParametresViewModel baseParametresViewModel;
        public ILocalNotificationService _localNotificationService;

        public INavigation _navigation;
        public IValidator _documentValidator;


  

        public string nomDocument
        {
            get => _document.nomDocument;

            set
            {
                _document.nomDocument = value;
                NotifyPropertyChanged("nomDocument");
            }
        }


        /// <summary>
        /// INFOS TYPE DOCUMENT
        /// </summary>
        public List<TypeDocument> TypedocumentList
        {
            get;
            set;
        }



        public string NomTypeDocument
        {
            get => _typeDocument.NomTypeDocument;

            set
            {
                _typeDocument.NomTypeDocument = value;
                NotifyPropertyChanged("NomTypeDocument");
            }
        }

        /// <summary>
        /// ///
        /// </summary>




        public string Code
        {
            get => _document.Code;
            set
            {
                _document.Code = value;
                NotifyPropertyChanged("Code");
            }
        }

        
        public bool? Periodicite
        {
            get => _document.Periodicite;
            set
            {
                _document.Periodicite = value;
                NotifyPropertyChanged("Periodicite");
            }
        }


        public string DescriptionDocument
        {
            get => _document.DescriptionDocument;
            set
            {
                _document.DescriptionDocument = value;
                NotifyPropertyChanged("DescriptionDocument");
            }
        }

        public DateTime DateEts
        {
            get => _document.DateEts;
            set
            {
                _document.DateEts = value;
                NotifyPropertyChanged("DateEts");
            }
        }

        public DateTime DateExp
        {
            get => _document.DateExp;
            set
            {
                _document.DateExp = value;
                NotifyPropertyChanged("DateExp");
            }
        }


        public TimeSpan HeureExp
        {
            get => _document.HeureExp;
            set
            {
                _document.HeureExp = value;
                NotifyPropertyChanged("HeureExp");
            }
        }

        public string Organisme
        {
            get => _document.Organisme;
            set
            {
                _document.Organisme = value;
                NotifyPropertyChanged("Organisme");
            }
        }



        public byte[] Photo
        {
            get => _document.Photo;
            set
            {
                _document.Photo = value;
                NotifyPropertyChanged("Photo");
            }
        }



        public byte[] Fichier
        {
            get => _document.Fichier;
            set
            {
                _document.Fichier = value;
                NotifyPropertyChanged("Fichier");
            }
        }

        public string NomduFichier
        {
            get => _document.NomduFichier;
            set
            {
                _document.NomduFichier = value;
                NotifyPropertyChanged("NomduFichier");
            }
        }

        public string AccesFichier
        {
            get => _document.AccesFichier;
            set
            {
                _document.AccesFichier = value;
                NotifyPropertyChanged("AccesFichier");
            }
        }



        List<Document> _documentList;
        public List<Document> DocumentList
        {
            get
            {
                List<Document> theCollection = new List<Document>();

                if (_documentList != null)
                {
                    List<Document> entities = (from e in _documentList
                                               where e.nomDocument.Contains(_searchText)
                                               select e).ToList<Document>();
                    if (entities != null && entities.Any())
                    {
                        theCollection = new List<Document>(entities);
                    }
                    else
                    {
                        
                    }
                }

                return theCollection;
            }
            set
            {
                _documentList = value;
                NotifyPropertyChanged("DocumentList");
            }
        }



        private string _searchText = string.Empty;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value) { _searchText = value ?? string.Empty; NotifyPropertyChanged("SearchText"); }

                if (SearchCommand.CanExecute(null))
                {
                    SearchCommand.Execute(null);
                }
            }
        }



        private Command _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new Command(DoSearchCommand, CanExecuteSearchCommand);
                return _searchCommand;
            }
        }
        private void DoSearchCommand()
        {
            // Refresh the list, which will automatically apply the search text
            NotifyPropertyChanged("DocumentList");
        }
        private bool CanExecuteSearchCommand()
        {
            return true;
        }


    }
}
