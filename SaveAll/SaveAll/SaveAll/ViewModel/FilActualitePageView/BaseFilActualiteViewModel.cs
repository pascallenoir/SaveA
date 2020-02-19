using System;
using System.Collections.Generic;
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

        public string DescriptionEvenement { get; set; }
        public DateTime? ProchainEvenemt { get; set; }
        public string nomEvenement { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string NomTypeMembre { get; set; }
        public string DescriptionDocument { get; set; }
        public string nomDocument { get; set; }
        public string NomTypeDocument { get; set; }
        public string NomDuBien { get; set; }
        public string NomTypePatrimoine { get; set; }
        public string DescriptionPatrimoine { get; set; }
        public List<Membre> MembreList { get; set; }
        public List<Document> DocumentList { get; set; }
        public List<Evenement> EvenementList { get; set; }
        public List<Patrimoine> PatrimoineList { get; set; }
        public List<TypeDocument> TypeDocumentList { get; set; }
        public List<TypeMembre> TypeMembreList { get; set; }
        public List<TypePatrimoine> TypePatrimoineList { get; set; }
        public Membre SelectedMembre { get; set; }
        public Document SelectedDocument { get; set; }
        public Evenement SelectedEvenement { get; set; }
        public Patrimoine SelectedPatrimoine { get; set; }

        void OnSelectedMembreChanged()
        {
            ShowMembreDetails(SelectedMembre.Id);
        }

        void OnSelectedDocumentChanged()
        {
            ShowDocumentsDetails(SelectedDocument.Id);
        }

        void OnSelectedEvenementChanged()
        {
            ShowEvenementDetails(SelectedEvenement.id);
        }

        void OnSelectedPatrimoineChanged()
        {
            ShowPatrimoineDetails(SelectedPatrimoine.Id);
        }

        [Obsolete]
        private void ShowMembreDetails(int selectedMembreID)
        {
            var pr = new DetailMembrePageView(selectedMembreID);
            _navigation.PushAsync(pr);
        }

        [Obsolete]
        private void ShowDocumentsDetails(int selectedDocumentID)
        {
            var pr = new DetailsDocumentPageView(selectedDocumentID);
            _navigation.PushAsync(pr);
        }

        [Obsolete]
        private void ShowEvenementDetails(int selectedEvenementID)
        {
            var pr = new DetailsEvenementPageView(selectedEvenementID);
            _navigation.PushAsync(pr);
        }

        [Obsolete]
        private void ShowPatrimoineDetails(int selectedPatrimoineID)
        {
            var pr = new DetailsPatrimoinePageView(selectedPatrimoineID);
            _navigation.PushAsync(pr);
        }
    }
}
