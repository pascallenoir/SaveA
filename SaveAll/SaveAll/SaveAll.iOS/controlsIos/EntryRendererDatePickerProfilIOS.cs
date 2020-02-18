using System;
using System.ComponentModel;
using CoreGraphics;
using SaveAll.Controls;
using SaveAll.iOS.controlsIos;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryRendererDatePickerProfil), typeof(EntryRendererDatePickerProfilIOS))]
namespace SaveAll.iOS.controlsIos
{
    public class EntryRendererDatePickerProfilIOS : DatePickerRenderer
    {
        public new static void Init() { }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender,e);


           
        }
    }
}