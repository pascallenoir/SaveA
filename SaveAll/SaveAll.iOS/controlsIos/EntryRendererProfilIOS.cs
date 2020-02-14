using System;
using CoreGraphics;
using SaveAll.Controls;
using SaveAll.iOS.controlsIos;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryRendererProfil), typeof(EntryRendererProfilIOS))]
namespace SaveAll.iOS.controlsIos
{
    public class EntryRendererProfilIOS : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;

            Control.Layer.CornerRadius = 6;
            Control.Layer.BorderWidth = 1;
            Control.Layer.BorderColor = Color.FromHex("#D1D0D0").ToCGColor();
            Control.Layer.BackgroundColor = Color.FromHex("#F1F1F1").ToCGColor();

            Control.LeftView = new UIKit.UIView(new CGRect(0, 0, 10, 0));
            Control.LeftViewMode = UIKit.UITextFieldViewMode.Always;
        }
    }
}
