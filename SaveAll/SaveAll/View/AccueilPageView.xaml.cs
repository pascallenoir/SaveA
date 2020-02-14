using System;
using System.Collections.Generic;
using SaveAll.Controls;
using SaveAll.Model;
using SaveAll.ViewModel.ViewModelUtilisateur;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccueilPageView : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }

        public AccueilPageView()
        {
            InitializeComponent();
            BindingContext = new AccueilViewModel(Navigation);

            menuList = new List<MasterPageItem>();

            username.Text = App.user.Login;
            var Accueil = new MasterPageItem() { Id = 1, Title = "Accueil", IconSource = "house.png", TargetType = typeof(FilActualitePageView) };
            var Profilutilisateur = new MasterPageItem() { Id = 2, Title = "Profil utilisateur", IconSource = "user.png", TargetType = typeof(ProfilPageView) };
            var Historique = new MasterPageItem() { Id = 3, Title = "Historique", IconSource = "completed_task.png", TargetType = typeof(HistoriquePageView) };
            var Parametre = new MasterPageItem() { Id = 4, Title = "Parametres", IconSource = "settings.png", TargetType = typeof(ParametresPageView) };
            var Calendrier = new MasterPageItem() { Id = 5, Title = "Calendrier", IconSource = "ic_error_outline.png", TargetType = typeof(CalendarPageView) };



            menuList.Add(Accueil);
            menuList.Add(Profilutilisateur);
            menuList.Add(Historique);
            menuList.Add(Parametre);
            menuList.Add(Calendrier);


            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(FilActualitePageView)));
        }




        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView

        private void OnMenuItemSelected(object sender, ItemTappedEventArgs e)
        {

            var item = e.Item as MasterPageItem;

            switch (item.Id)
            {

                case 1:

                    Type page = item.TargetType;
                    Detail =  new NavigationPage((Page)Activator.CreateInstance(page));
                    
                    break;

                case 2:
                    Detail = new NavigationPage(new ProfilPageView());
                    
                    break;

                case 3:
                    Detail = new NavigationPage(new HistoriquePageView());

                    break;

                case 4:
                    Detail = new NavigationPage(new ParametresPageView());

                    break;

                case 5:
                    Detail = new NavigationPage(new CalendarPageView());

                    break;

              
            }
            ((ListView)sender).SelectedItem = null;
            IsPresented = false;


        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
