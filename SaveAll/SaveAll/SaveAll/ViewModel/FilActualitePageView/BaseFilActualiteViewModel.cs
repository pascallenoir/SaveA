using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SaveAll.FrameworkMVVM;
using SaveAll.Model;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.FilActualitePageView
{
    public class BaseFilActualiteViewModel : ViewModelDeBase
    {
        public Document _document;
        public Membre _membre;
        public Evenement _evenement;
        public Patrimoine _patrimoine;
        public TypeDocument _typeDocument;
        public TypeMembre _typeMembre;
        public TypePatrimoine _typePatrimoine;
        public TypeEvenement _typeEvenement;
        public INavigation _navigation;



        // information de la classe membre

        public string Nom
        {
            get => _membre.Nom;
            set
            {
                _membre.Nom = value;
                NotifyPropertyChanged("Nom");
            }
        }


        public string Prenom
        {
            get => _membre.Prenom;
            set
            {
                _membre.Prenom = value;
                NotifyPropertyChanged("Prenom");
            }
        }


        public string Adresse
        {
            get => _membre.Adresse;
            set
            {
                _membre.Adresse = value;
                NotifyPropertyChanged("Adresse");
            }
        }


        public string NomTypeMembre
        {
            get => _typeMembre.NomTypeMembre;
            set
            {
                _typeMembre.NomTypeMembre = value;
                NotifyPropertyChanged("NomTypeMembre");
            }
        }



        Membre selectedMembre;
        public Membre SelectedMembre
        {
            get
            {
                return selectedMembre;
            }
            set
            {
                if (selectedMembre != value)
                {
                    selectedMembre = value;
                    NotifyPropertyChanged("SelectedMembre");
                    ShowMembreDetails(value.Id);
                }
            }
        }

        [Obsolete]
        private void ShowMembreDetails(int selectedMembreID)
        {
            var pr = new DetailMembrePageView(selectedMembreID);
            _navigation.PushAsync(pr);
        }


        // informations de la classe document

        public string DescriptionDocument
        {
            get => _document.DescriptionDocument;
            set
            {
                _document.DescriptionDocument = value;
                NotifyPropertyChanged("DescriptionDocument");
            }
        }

        public string nomDocument
        {
            get => _document.nomDocument;

            set
            {
                _document.nomDocument = value;
                NotifyPropertyChanged("nomDocument");
            }
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




        Document selectedDocument;
        public Document SelectedDocument
        {
            get
            {
                return selectedDocument;
            }
            set
            {
                if (selectedDocument != value)
                {
                    selectedDocument = value;
                    NotifyPropertyChanged("SelectedDocument");
                    ShowDocumentsDetails(value.Id);
                }
            }
        }




        [Obsolete]
        private void ShowDocumentsDetails(int selectedDocumentID)
        {
            var pr = new DetailsDocumentPageView(selectedDocumentID);
            _navigation.PushAsync(pr);
        }


        // information de la classe evenement

        public string DescriptionEvenement
        {
            get => _evenement.DescriptionEvenement;
            set
            {
                _evenement.DescriptionEvenement = value;
                NotifyPropertyChanged("DescriptionEvenement");
            }
        }


        public DateTime? ProchainEvenemt
        {
            get => _evenement.ProchainEvenemt;
            set
            {
                _evenement.ProchainEvenemt = value;
                NotifyPropertyChanged("ProchainEvenemt");
            }
        }

        public string nomEvenement
        {
            get => _evenement.nomEvenement;

            set
            {
                _evenement.nomEvenement = value;
                NotifyPropertyChanged("nomEvenement");
            }
        }

      

        Evenement selectedEvenement;
        public Evenement SelectedEvenement
        {
            get
            {
                return selectedEvenement;
            }
            set
            {
                if (selectedEvenement != value)
                {
                    selectedEvenement = value;
                    NotifyPropertyChanged("SelectedEvenement");
                    ShowEvenementDetails(value.id);
                }
            }
        }

        [Obsolete]
        private void ShowEvenementDetails(int selectedEvenementID)
        {
            var pr = new DetailsEvenementPageView(selectedEvenementID);
            
            _navigation.PushAsync(pr);
        }


        //Informartions de la classe patrimoine

        public string NomDuBien
        {
            get => _patrimoine.NomDuBien;

            set
            {
                _patrimoine.NomDuBien = value;
                NotifyPropertyChanged("NomDuBien");
            }
        }


        public string NomTypePatrimoine
        {
            get => _typePatrimoine.NomTypePatrimoine;

            set
            {
                _typePatrimoine.NomTypePatrimoine = value;
                NotifyPropertyChanged("NomTypePatrimoine");
            }
        }


        public string DescriptionPatrimoine
        {
            get => _patrimoine.DescriptionPatrimoine;

            set
            {
                _patrimoine.DescriptionPatrimoine = value;
                NotifyPropertyChanged("DescriptionPatrimoine");
            }
        }

        Patrimoine selectedPatrimoine;
        public Patrimoine SelectedPatrimoine
        {
            get
            {
                return selectedPatrimoine;
            }
            set
            {
                if (selectedPatrimoine != value)
                {
                    selectedPatrimoine = value;
                    NotifyPropertyChanged("SelectedPatrimoine");
                    ShowPatrimoineDetails(value.Id);
                }
            }
        }

        [Obsolete]
        private void ShowPatrimoineDetails(int selectedPatrimoineID)
        {
            var pr = new DetailsPatrimoinePageView(selectedPatrimoineID);
            
            _navigation.PushAsync(pr);
        }


        // listes des 04 classes 


        List<Membre> _membreList;
        public List<Membre> MembreList
        {
            get => _membreList;
            set
            {
                _membreList = value;
                NotifyPropertyChanged("MembreList");
            }
        }



        List<Document> _documentList;
        public List<Document> DocumentList
        {
            get => _documentList;
            set
            {
                _documentList = value;
                NotifyPropertyChanged("DocumentList");
            }
        }


        List<Evenement> _evenementList;
        public List<Evenement> EvenementList
        {
            get => _evenementList;
            set
            {
                _evenementList = value;
                NotifyPropertyChanged("EvenementList");
            }
        }

        List<Patrimoine> _patrimoineList;
        public List<Patrimoine> PatrimoineList
        {
            get => _patrimoineList;
            set
            {
                _patrimoineList = value;
                NotifyPropertyChanged("PatrimoineList");
            }
        }


        // listes des types des 04 classes

        List<TypeDocument> _typedocumentList;
        public List<TypeDocument> TypeDocumentList
        {
            get => _typedocumentList;
            set
            {
                _typedocumentList = value;
                NotifyPropertyChanged("TypeDocumentList");
            }
        }


        List<TypeMembre> _typemembreList;
        public List<TypeMembre> TypeMembreList
        {
            get => _typemembreList;
            set
            {
                _typemembreList = value;
                NotifyPropertyChanged("TypeMembreList");
            }
        }


        List<TypePatrimoine> _typepatrimoineList;
        public List<TypePatrimoine> TypePatrimoineList
        {
            get => _typepatrimoineList;
            set
            {
                _typepatrimoineList = value;
                NotifyPropertyChanged("TypePatrimoineList");
            }
        }


    }
}
