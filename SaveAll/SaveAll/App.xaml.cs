using DLToolkit.Forms.Controls;
using SaveAll.Helpers;
using SaveAll.Model;
using SaveAll.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveAll
{
    public partial class App : Application
    {
        public static Membre user { get; set; }
        public static Membre MembreActuel { get; set; }

        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjA0NTUwQDMxMzcyZTM0MmUzMFA3R0d4VjNjZ015R21JMU9RYkZiQWplcmlzMEhreUp6NjRKUVRzbE5jWkk9");

            InitializeComponent();
            var t = new DatabaseHelper();
            FlowListView.Init();

            MainPage = new NavigationPage(new IdentityCardpage());
            
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
