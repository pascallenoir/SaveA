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

        public bool Notifications { get; set; }
    }
}
