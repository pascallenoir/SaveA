using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Interfaces;
using SaveAll.Model;
using SaveAll.View;
using Xamarin.Forms;

namespace SaveAll.ViewModel.FilActualitePageView
{
    public class ListFilActualiteViewModel : BaseFilActualiteViewModel
    {
        // Commande pour les evenements
        public ICommand AjoutEvenementCommand { get; private set; }
        public ICommand DeleteEvenementCommand { get; private set; }
        public ICommand AllerAListeEvenementCommand { get; private set; }
       

        // Commande pour les documents
        public ICommand AjouterDocumentCommand { get; private set; }
        public ICommand SupprimerDocumentCommand { get; private set; }
        public ICommand AllerAListeDocumentCommand { get; private set; }



        // Commande pour les membres
        public ICommand AjouterMembreCommand { get; private set; }
        public ICommand SupprimerMembreCommand { get; private set; }
        public ICommand AllerAListeMembreCommand { get; private set; }


        // Commande pour le patrimoine
        public ICommand AjouterBienCommand { get; private set; }
        public ICommand SupprimerPatrimoineCommand { get; private set; }
        public ICommand AllerAListePatrimoineCommand { get; private set; }

        public ListFilActualiteViewModel(INavigation navigation)
        {

            _navigation = navigation;
            _document = new Document();
            _membre = new Membre();
            _evenement = new Evenement();
            _patrimoine = new Patrimoine();
            _typeMembre = new TypeMembre();
            _typePatrimoine = new TypePatrimoine();
            _typeDocument = new TypeDocument();
       


            AjoutEvenementCommand = new Command(async () => await AjouterUnEvenement());
            DeleteEvenementCommand = new Command(async () => await SupprimerUnEvenement ());
            AllerAListeEvenementCommand = new Command(async () => await AllerAlaListeDesEvenements());

            AjouterDocumentCommand = new Command(async () => await AjouterUnDocument());
            SupprimerDocumentCommand = new Command(async () => await SupprimerUnDocument());
            AllerAListeDocumentCommand = new Command(async () => await AllerAlaListeDesDocuments());

            AjouterMembreCommand = new Command(async () => await AjouterUnMembre());
            SupprimerMembreCommand = new Command(async () => await SupprimerUnMembre());
            AllerAListeMembreCommand = new Command(async () => await AllerAlaListeDesMembres());

            AjouterBienCommand = new Command(async () => await AjouterBien());
            SupprimerPatrimoineCommand = new Command(async () => await SupprimerPatrimoine());
            AllerAListePatrimoineCommand = new Command(async () => await AllerAListePatrimoine());


            MessagingCenter.Subscribe<App>((App)Application.Current, "ActualiserListe", (sender) =>
            {
                FetchPatrimoine();
                FetchEvenements();
                FetchMembre();
                FetchDocumentsAsync();
            });



            FetchPatrimoine();
            FetchEvenements();
            FetchMembre();
            FetchDocumentsAsync();

        }


        /// <summary>
        /// fonctionnalites sur le patrimoine : ajout, suppression, liste
        /// </summary>
        /// <returns></returns>


        // aller a la liste du patrimoine

        async Task AllerAListePatrimoine()
        {
            await _navigation.PushAsync(new HistoriquePatrimoine());
        }

        // supprimer un bien

        async Task SupprimerPatrimoine()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionelement, "Supprimer", "Annuler");
            if (isUserAccept)
            {
                new DatabaseHelper().SupprimerEvenement(_patrimoine.Id);

                await Application.Current.MainPage.DisplayAlert(Messages.MessageSucces, Messages.MessageOkSuppression, "OK");

            }
        }

        //Ajouter un bien
        [Obsolete]
        async Task AjouterBien()
        {
            var pr = new NouveauPatrimoinePageView();

            await PopupNavigation.PushAsync(pr);
        }


       

        //fonctionnalites sur membre
        async Task AllerAlaListeDesMembres()
        {
            await _navigation.PushAsync(new HistoriqueMembre());

        }

        /// <summary>
        /// Ajouter un nouvea membre
        /// </summary>
        /// <returns></returns>

        [Obsolete]
        async Task AjouterUnMembre()
        {
            var pr = new NouveauMembrePageView();
           
            await PopupNavigation.PushAsync(pr);
        }

        

        async Task SupprimerUnMembre()
        {

            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionelement, "Supprimer", "Annuler");
            if (isUserAccept)
            {
                new DatabaseHelper().SupprimerEvenement(_membre.Id);
               
                await Application.Current.MainPage.DisplayAlert(Messages.MessageSucces, Messages.MessageOkSuppression, "OK");

            }
        }


        //fonctionnalites sur document

        async Task AllerAlaListeDesDocuments()
        {
            await _navigation.PushAsync(new HistoriqueDocument());
        }

        async Task SupprimerUnDocument()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionelement, "Supprimer", "Annuler");
            if (isUserAccept)
            {
                await new DatabaseHelper().SupprimerDocumentsAsync(_document.Id);

                await Application.Current.MainPage.DisplayAlert(Messages.MessageSucces, Messages.MessageOkSuppression, "OK");
            }
        }


        /// <summary>
        /// Ajouter un nouveau document
        /// </summary>
        /// <returns></returns>

        [Obsolete]
        async Task AjouterUnDocument()
        {
            var pr = new NouveauDocumentPageView();
           
            await PopupNavigation.PushAsync(pr);
        }



        //fonctionnalites sur evenement

        async Task AllerAlaListeDesEvenements()
        {
            await _navigation.PushAsync(new HistoriqueEvenement());
        }

        async Task SupprimerUnEvenement()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageSuppression, Messages.MessageAlerteSuppresionelement, "Supprimer", "Annuler");
            if (isUserAccept)
            {
                await new DatabaseHelper().SupprimerMembreAsync(_evenement.id);

                await Application.Current.MainPage.DisplayAlert(Messages.MessageSucces, Messages.MessageOkSuppression, "OK");
            }
        }

        /// <summary>
        /// Ajouter un nouvel evenement
        /// </summary>
        /// <returns></returns>

        [Obsolete]
        async Task AjouterUnEvenement()
        {
            var pr = new NouvelEvenementPageView();
           
            await PopupNavigation.PushAsync(pr);
        }



        /// <summary>
        /// fonctionnalites d'affichage
        /// </summary>
        /// <returns></returns>

        async Task FetchDocumentsAsync()
        {
            DocumentList.Clear();
            DocumentList.AddRange(await App.MembreActuel.SesDocuments());

            TypeDocumentList = await new DatabaseHelper().TousLesTypesDocumentsAsync();
            // fonctionnalite pour recuperer tous les enregistrements

        }


        async Task FetchMembre()
        {

                MembreList = await App.MembreActuel.EnfantsAsync();
         
            // fonctionnalite pour recuperer tous les enregistrements
        }

        async Task FetchEvenements()
        {

                EvenementList = await App.MembreActuel.SesEvenementsAsync();
            // fonctionnalite pour recuperer tous les enregistrements
        }



        async Task FetchPatrimoine()
        {
            PatrimoineList = await App.MembreActuel.SesBiens();
            // fonctionnalite pour recuperer tous les enregistrements
        }



    }
}
