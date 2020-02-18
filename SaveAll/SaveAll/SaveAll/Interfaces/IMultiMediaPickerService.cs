using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaveAll.Model;

namespace SaveAll.Interfaces
{
    public interface IMultiMediaPickerService
    {

        event EventHandler<Patrimoine> OnMediaPicked;
        event EventHandler<IList<Patrimoine>> OnMediaPickedCompleted;
        Task<IList<Patrimoine>> PickPhotosAsync();
        Task<IList<Patrimoine>> PickVideosAsync();
        void Clean();
    }
}
