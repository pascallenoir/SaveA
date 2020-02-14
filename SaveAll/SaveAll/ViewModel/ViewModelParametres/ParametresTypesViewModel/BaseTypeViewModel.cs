using FluentValidation;
using SaveAll.FrameworkMVVM;
using SaveAll.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelParametres.ParametresTypesViewModel
{
    public class BaseTypeViewModel : ViewModelDeBase
    {
        public INavigation _navigation;
        public IValidator _AjouterTypeMembreValidator;
        public IValidator _AjouterTypeDocumentValidator;
        public IValidator _AjouterTypePatrimoineValidator;
        public IValidator _AjouterTypeEvenementValidator;

        public TypeEvenement _typeEvenment;
        public TypeDocument _typeDocument;
        public TypeMembre _typeMembre;
        public TypePatrimoine _typePatrimoine;





        public string NomTypeMembre
        {
            get => _typeMembre.NomTypeMembre;
            set
            {
                _typeMembre.NomTypeMembre = value;
                NotifyPropertyChanged("NomTypeMembre");
            }
        }


        public string Nom
        {
            get => _typeEvenment.Nom;
            set
            {
                _typeEvenment.Nom = value;
                NotifyPropertyChanged("Nom");
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


        public string NomTypePatrimoine
        {
            get => _typePatrimoine.NomTypePatrimoine;
            set
            {
                _typePatrimoine.NomTypePatrimoine = value;
                NotifyPropertyChanged("NomTypePatrimoine");
            }
        }






        // listes des 04 classes types


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



        List<TypeDocument> _typeDocumentList;
        public List<TypeDocument> TypeDocumentList
        {
            get => _typeDocumentList;
            set
            {
                _typeDocumentList = value;
                NotifyPropertyChanged("TypeDocumentList");
            }
        }


        List<TypeEvenement> _typeEvenmentList;
        public List<TypeEvenement> TypeEvenementList
        {
            get => _typeEvenmentList;
            set
            {
                _typeEvenmentList = value;
                NotifyPropertyChanged("TypeEvenementList");
            }
        }

        List<TypePatrimoine> _typePatrimoineList;
        public List<TypePatrimoine> TypePatrimoineList
        {
            get => _typePatrimoineList;
            set
            {
                _typePatrimoineList = value;
                NotifyPropertyChanged("TypePatrimoineList");
            }
        }
    }
}
