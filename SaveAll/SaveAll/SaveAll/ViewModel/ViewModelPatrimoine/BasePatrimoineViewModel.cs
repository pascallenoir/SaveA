using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using SaveAll.FrameworkMVVM;
using SaveAll.Helpers;
using SaveAll.Interfaces;
using SaveAll.Model;
using SaveAll.View;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SaveAll.ViewModel.ViewModelPatrimoine
{
    public class BasePatrimoineViewModel : ViewModelDeBase
    {
        public Patrimoine _patrimoine;
        public TypePatrimoine _typePatrimoine;
        public INavigation _navigation;

        public IMultiMediaPickerService _multiMediaPickerService;
        public ObservableCollection<Patrimoine> Media { get; set; }

        public string NomDuBien { get; set; }
        public string NumeroDuBien { get; set; }
        public string DescriptionPatrimoine { get; set; }

        /// <summary>
        /// INFOS TYPE PATRIMOINE
        /// </summary>

        public List<TypePatrimoine> TypePatrimoineList { get; set; }

        public string NomTypePatrimoine { get; set; }
        public DateTime? DateAcquisition { get; set; }
        public string ValeurAcquisition { get; set; }
        public string ValeurActuel { get; set; }
        public string Path { get; set; }
        public string PreviewPath { get; set; }
        public string SearchText { get; set; }

        public ObservableRangeCollection<Patrimoine> PatrimoineList { get; set; } = new ObservableRangeCollection<Patrimoine>();
        public ObservableRangeCollection<Patrimoine> SearchPatrimoineList { get; set; } = new ObservableRangeCollection<Patrimoine>();

        public MvvmHelpers.Commands.Command<string> SearchCommand { get; set; }

        public BasePatrimoineViewModel()
        {
            //   PinCollection.Add(new Pin() { Position = MyPosition, Type = PinType.Generic, Label = "" + NomDuBien });
            //
            //
            //   Task.Run(async () =>
            //	{
            //		var position = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync();
            //       MyPosition = new Position(position.Latitude, position.Longitude);
            //
            //   });

            SearchCommand = new MvvmHelpers.Commands.Command<string>(searchText => DoSearchCommand(searchText));

            PatrimoineList.CollectionChanged += PatrimoineList_CollectionChanged;
        }

        private void PatrimoineList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SearchPatrimoineList.Clear();
            SearchPatrimoineList.AddRange(PatrimoineList);
        }

        void DoSearchCommand(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                SearchPatrimoineList.Clear();
                SearchPatrimoineList.AddRange(PatrimoineList);
            }
            else
            {
                SearchPatrimoineList.Clear();
                SearchPatrimoineList.AddRange(PatrimoineList.Where(x => x.NomDuBien.Contains(searchText)));
            }
        }

        //  private ObservableCollection<Pin> _pinCollection = new ObservableCollection<Pin>();
        //
        //  public ObservableCollection<Pin> PinCollection
        //  {
        //      get
        //      {
        //          return _pinCollection;
        //
        //      }
        //      set
        //      {
        //          _pinCollection = value;
        //          NotifyPropertyChanged("PinCollection");
        //      }
        //  }



        //  public Position MyPosition
        //  { 
        //      get => _patrimoine.MyPosition.ToPosition();
        //      set
        //      {
        //          _patrimoine.MyPosition = value.ToStringPosition();
        //          NotifyPropertyChanged("MyPosition");
        //      }
        //  }
        //





        //  public double Longitude
        //  {
        //      get => _patrimoine.Longitude;
        //      set
        //      {
        //          _patrimoine.Longitude = value;
        //          NotifyPropertyChanged("Longitude");
        //      }
        //  }
        //
        //
        //
        //  public double Latitude
        //  {
        //      get => _patrimoine.Latitude;
        //      set
        //      {
        //          _patrimoine.Latitude = value;
        //          NotifyPropertyChanged("Latitude");
        //      }
        //  }
        //

    }
}
