using SaveAll.FrameworkMVVM;
using SaveAll.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SaveAll.ViewModel.ViewModelParametres
{
    public class BaseParametresViewModel : ViewModelDeBase
    {

        public INavigation _navigation;



        bool _notifications = true;
        public bool Notifications
        {
            get => _notifications;
            set
            {
                _notifications = value;
                NotifyPropertyChanged("Notifications");
            }
        }




       
    }
}
