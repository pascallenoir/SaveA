using System;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Support.V4.Content;
using Com.Xamarin.Formsviewgroup;
using SaveAll.Droid.PlatformSpecifics;
using SaveAll.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileProvider))]
namespace SaveAll.Droid.PlatformSpecifics
{
    public class LocalFileProvider : ILocalFileProvider
    {


        [Obsolete]
        public void OpenFile(string path,string fileName)
        {
            var context = Android.App.Application.Context;

            try
            {

            var documentsPath = path;
            var filePath = Path.Combine(documentsPath);

            var bytes = File.ReadAllBytes(documentsPath);

            //Copy the private file's data to the EXTERNAL PUBLIC location
            string externalStorageState = global::Android.OS.Environment.ExternalStorageState;
            var externalPath = global::Android.OS.Environment.ExternalStorageDirectory.Path + "/" + global::Android.OS.Environment.DirectoryDownloads + "/" + fileName;
            File.WriteAllBytes(externalPath, bytes);

            Java.IO.File file = new Java.IO.File(externalPath);
            file.SetReadable(true);

            string application = "";
            string extension = Path.GetExtension(filePath);

            // get mimeTye
            switch (extension.ToLower())
            {
                case ".txt":
                    application = "text/plain";
                    break;
                case ".doc":
                case ".docx":
                    application = "application/msword";
                    break;
                case ".pdf":
                    application = "application/pdf";
                    break;
                case ".xls":
                case ".xlsx":
                    application = "application/vnd.ms-excel";
                    break;
                case ".jpg":
                case ".jpeg":
                case ".png":
                    application = "image/jpeg";
                    break;
                default:
                    application = "*/*";
                    break;
            }

                     //Android.Net.Uri uri = Android.Net.Uri.Parse("file://" + filePath);
                     Android.Net.Uri uri = FileProvider.GetUriForFile(context, "com.companyname.saveall.fileprovider", file);
                     context.GrantUriPermission(context.PackageName, uri, ActivityFlags.GrantReadUriPermission);
                     Intent intent = new Intent(Intent.ActionView);
                     intent.SetDataAndType(uri, application);
                     intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

                Forms.Context.StartActivity(intent);

            }

             catch (ActivityNotFoundException anfe)
            {
                // android could not find a suitable app for this file
                var alert = new AlertDialog.Builder(context);
                alert.SetTitle("Error");
                alert.SetMessage("No suitable app found to open this file");
                alert.SetCancelable(false);
                alert.SetPositiveButton("Okay", (object sender, DialogClickEventArgs e) => ((AlertDialog)sender).Hide());
                alert.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
