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
using UserNotifications;
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

            //For banner notification
            UNUserNotificationCenter.Current.Delegate = new iOSBannerNotification();
            //Ask user permission to display notification . its support for iOS 8

            // We have checked to see if the device is running iOS 8, if so we are required to ask for the user's permission to receive notifications      
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
                    UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
                );

                UIApplication.SharedApplication.RegisterUserNotificationSettings(notificationSettings);
            }



            // check for a notification      
            if (launchOptions != null)
            {
                if (launchOptions.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
                {
                    UILocalNotification localNotification = launchOptions[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
                    if (localNotification != null)
                    {
                        new UIAlertView(localNotification.AlertAction, localNotification.AlertBody, null, "OK", null).Show();
                        // reset our badge      
                        UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
                    }
                }
            }


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

        //iOSBannerNotification is  a seperate class
        public class iOSBannerNotification : UNUserNotificationCenterDelegate
        {
            public iOSBannerNotification()
            {

            }
            public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
            {
                completionHandler(UNNotificationPresentationOptions.Alert);
            }
        }

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {

            UIAlertController okayAlertController = UIAlertController.Create(notification.AlertAction, notification.AlertBody, UIAlertControllerStyle.Alert);
            okayAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }

    }
}
