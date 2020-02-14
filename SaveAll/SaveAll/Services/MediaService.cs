using System;
using System.IO;
using System.Threading.Tasks;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using SaveAll.Controls;
using SaveAll.Interfaces;
using Xamarin.Forms;

namespace SaveAll.Services
{
    public class MediaService : ImMediaServices
    {

        
        public async Task<byte[]> GetImageStreamAsync()
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            return stream != null ? GetBytesFromStream(stream) : null;
        }


        public async Task<byte[]> PickAndShowFileAsync()
        {
            
            var result = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                SaveToAlbum = true,
                AllowCropping = true


            });

            //Get the public album path
            var Patha = result.AlbumPath;

          
            return result != null ? GetBytesFromStreamTakePhoto(result.GetStream()) : null;
           
        }


        byte[] GetBytesFromStream(Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }






        byte[] GetBytesFromStreamTakePhoto(Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }



       


    }
}
