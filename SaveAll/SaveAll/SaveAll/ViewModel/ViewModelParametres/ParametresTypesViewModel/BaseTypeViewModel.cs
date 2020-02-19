using FluentValidation;
using MvvmHelpers;
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

        public string NomTypeMembre { get; set; }
        public string Nom { get; set; }
        public string NomTypeDocument { get; set; }
        public string NomTypePatrimoine { get; set; }

        // listes des 04 classes types

        public ObservableRangeCollection<TypeMembre> TypeMembreList { get; set; } = new ObservableRangeCollection<TypeMembre>();
        public ObservableRangeCollection<TypeDocument> TypeDocumentList { get; set; } = new ObservableRangeCollection<TypeDocument>();
        public ObservableRangeCollection<TypeEvenement> TypeEvenementList { get; set; } = new ObservableRangeCollection<TypeEvenement>();
        public ObservableRangeCollection<TypePatrimoine> TypePatrimoineList { get; set; } = new ObservableRangeCollection<TypePatrimoine>();
    }
}
