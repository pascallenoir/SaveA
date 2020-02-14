using System;
using System.Threading.Tasks;

namespace SaveAll.Interfaces
{
    public interface ImMediaServices
    {
        Task<byte[]> PickAndShowFileAsync();

        Task<byte[]> GetImageStreamAsync();


    }
}
