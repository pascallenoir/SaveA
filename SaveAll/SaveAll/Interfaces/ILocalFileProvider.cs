using System;
using System.IO;
using System.Threading.Tasks;

namespace SaveAll.Interfaces
{
    public interface ILocalFileProvider
    {
        void OpenFile(string path, string fileName);
    }
}