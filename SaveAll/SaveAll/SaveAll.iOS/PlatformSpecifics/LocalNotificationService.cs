﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using SaveAll.Interfaces;
using SaveAll.iOS.PlatformSpecifics;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalNotificationService))]
namespace SaveAll.iOS.PlatformSpecifics
{
    public class LocalNotificationService : ILocalNotificationService
    {

        const string NotificationKey = "LocalNotificationKey";

        public void LocalNotification(string title, string body, int id, DateTime notifyTime)
        {

            var notification = new UILocalNotification
            {

                AlertTitle = title,
                AlertBody = body,
                SoundName = UILocalNotification.DefaultSoundName,
                FireDate = notifyTime.ToNSDate(),
                RepeatInterval = NSCalendarUnit.Calendar,

                UserInfo = NSDictionary.FromObjectAndKey(NSObject.FromObject(id), NSObject.FromObject(NotificationKey))
            };
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }

        public void Cancel(int id)
        {

            var notifications = UIApplication.SharedApplication.ScheduledLocalNotifications;
            var notification = notifications.Where(n => n.UserInfo.ContainsKey(NSObject.FromObject(NotificationKey)))
                .FirstOrDefault(n => n.UserInfo[NotificationKey].Equals(NSObject.FromObject(id)));
            UIApplication.SharedApplication.CancelAllLocalNotifications();
            if (notification != null)
            {
                UIApplication.SharedApplication.CancelLocalNotification(notification);
                UIApplication.SharedApplication.CancelAllLocalNotifications();
            }
        }
    }

    public static class DateTimeExtensions
    {

        static DateTime nsUtcRef = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        // last zero is milliseconds      

        public static double SecondsSinceNSRefenceDate(this DateTime dt)
        {
            return (dt.ToUniversalTime() - nsUtcRef).TotalSeconds;
        }

        public static NSDate ToNSDate(this DateTime dt)
        {
            return NSDate.FromTimeIntervalSinceReferenceDate(dt.SecondsSinceNSRefenceDate());
        }
    }
}