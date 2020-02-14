using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using SaveAll.Interfaces;
using SaveAll.iOS.PlatformSpecifics;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileProvider))]
namespace SaveAll.iOS.PlatformSpecifics
{
    public class LocalFileProvider : ILocalFileProvider
    {
        public void OpenFile(string path, string fileName)
        {

        try
        {

            var documentsPath = path;
            var filePath = Path.Combine(documentsPath, fileName);

            //Device.OpenUri(new Uri(filePath));
            var PreviewController = UIDocumentInteractionController.FromUrl(NSUrl.FromFilename(filePath));
            PreviewController.Delegate = new UIDocumentInteractionControllerDelegateClass(UIApplication.SharedApplication.KeyWindow.RootViewController);
            Device.BeginInvokeOnMainThread(() =>
            {
                PreviewController.PresentPreview(true);
            });

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        }

        public class UIDocumentInteractionControllerDelegateClass : UIDocumentInteractionControllerDelegate
        {
        UIViewController ownerVC;

        public UIDocumentInteractionControllerDelegateClass(UIViewController vc)
        {
            ownerVC = vc;
        }

        public override UIViewController ViewControllerForPreview(UIDocumentInteractionController controller)
        {
            return ownerVC;
        }

        public override UIView ViewForPreview(UIDocumentInteractionController controller)
        {
            return ownerVC.View;
        }

        }


    }
}