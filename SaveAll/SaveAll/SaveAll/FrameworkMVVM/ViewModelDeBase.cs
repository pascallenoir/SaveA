//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;
//using System.Text;
using PropertyChanged;

namespace SaveAll.FrameworkMVVM
{
    [AddINotifyPropertyChangedInterface]
    public abstract class ViewModelDeBase //: INotifyPropertyChanged
    {
        protected ViewModelDeBase()
        {

        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //public void NotifyPropertyChanged(string nomPropriete)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomPropriete));
        //}
        //public bool NotifyPropertyChanged<T>(ref T variable, T valeur, [CallerMemberName] string nomPropriete = null)
        //{
        //    if (Equals(variable, valeur)) return false;
        //    variable = valeur;
        //    NotifyPropertyChanged(nomPropriete);
        //    return true;
        //}
    }
}
