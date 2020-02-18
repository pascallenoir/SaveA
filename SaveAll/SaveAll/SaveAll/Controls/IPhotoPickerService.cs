using System;
using System.IO;
using System.Threading.Tasks;

namespace SaveAll.Controls
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
