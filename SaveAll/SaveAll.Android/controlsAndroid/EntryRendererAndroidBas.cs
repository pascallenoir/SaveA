using System;
using Android.Content;
using SaveAll.Controls;
using SaveAll.Droid.controlsAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryRendererIdentiteBas), typeof(EntryRendererAndroidBas))]
namespace SaveAll.Droid.controlsAndroid
{
    public class EntryRendererAndroidBas : EntryRenderer
    {
        public EntryRendererAndroidBas(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.SetBackgroundResource(Resource.Layout.rounded_shapeIdentificationBas);
                //var gradientDrawable = new GradientDrawable();
                //gradientDrawable.SetCornerRadius(60f);
                //gradientDrawable.SetStroke(5, Android.Graphics.Color.DeepPink);
                //gradientDrawable.SetColor(Android.Graphics.Color.LightGray);
                //Control.SetBackground(gradientDrawable);
                //
                //Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight,
                //    Control.PaddingBottom);
            }
        }
    }

}
