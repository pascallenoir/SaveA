using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Platform;
using Flex;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using PanCardView.iOS;
using Plugin.Geolocator;
using SaveAll.iOS.controlsIos;
using SaveAll.iOS.PlatformSpecifics;
using Syncfusion.SfCalendar.XForms.iOS;
using UIKit;
using Xamarin.Forms;
namespace SaveAll.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            // initialisation des composants
            Rg.Plugins.Popup.Popup.Init();
            Forms.SetFlags("CollectionView_Experimental");

            //test


            global::Xamarin.Forms.Forms.Init();
            // initialisation des composants
            AiForms.Renderers.iOS.SettingsViewInit.Init(); //need to write here
            SfCalendarRenderer.Init();

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();
            Xamarin.FormsMaps.Init();
            CardsViewRenderer.Preserve();
            ImageCircleRenderer.Init();
            FlexButton.Init();
            FormsMaterial.Init();
            // Fin initialisation des composants

            LoadApplication(new App());
            FloatingActionButtonRenderer.InitRenderer();
            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
