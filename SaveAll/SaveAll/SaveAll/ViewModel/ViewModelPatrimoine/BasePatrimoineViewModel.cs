using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
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
     


        public string NomDuBien
        {
            get => _patrimoine.NomDuBien;

            set
            {
                _patrimoine.NomDuBien = value;
                NotifyPropertyChanged("NomDuBien");
            }
        }

        public string NumeroDuBien
        {
            get => _patrimoine.NumeroDuBien;

            set
            {
                _patrimoine.NumeroDuBien = value;
                NotifyPropertyChanged("NumeroDuBien");
            }
        }

        public string DescriptionPatrimoine
        {
            get => _patrimoine.DescriptionPatrimoine;

            set
            {
                _patrimoine.DescriptionPatrimoine = value;
                NotifyPropertyChanged("DescriptionPatrimoine");
            }
        }


        /// <summary>
        /// INFOS TYPE PATRIMOINE
        /// </summary>

        public List<TypePatrimoine> TypePatrimoineList
        {
            get;
            set;
        }

        public string NomTypePatrimoine
        {
            get => _typePatrimoine.NomTypePatrimoine;

            set
            {
                _typePatrimoine.NomTypePatrimoine = value;
                NotifyPropertyChanged("NomTypePatrimoine");
            }
        }

        public DateTime? DateAcquisition
        {
            get => _patrimoine.DateAcquisition;

            set
            {
                _patrimoine.DateAcquisition = value;
                NotifyPropertyChanged("DateAcquisition");
            }

        }

        public string ValeurAcquisition
        {
            get => _patrimoine.ValeurAcquisition;

            set
            {
                _patrimoine.ValeurAcquisition = value;
                NotifyPropertyChanged("ValeurAcquisition");
            }

        }


        public string ValeurActuel
        {
            get => _patrimoine.ValeurActuel;

            set
            {
                _patrimoine.ValeurActuel = value;
                NotifyPropertyChanged("ValeurActuel");
            }

        }

   

        public string Path
        {
            get => _patrimoine.Path;
            set
            {
                _patrimoine.Path = value;
                NotifyPropertyChanged("Path");
            }
        }

        public string PreviewPath
        {
            get => _patrimoine.PreviewPath;
            set
            {
                _patrimoine.PreviewPath = value;
                NotifyPropertyChanged("PreviewPath");
            }
        }

       

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




        List<Patrimoine> _patrimoineList;
        public List<Patrimoine> PatrimoineList
        {
            get
            {
                List<Patrimoine> theCollection = new List<Patrimoine>();

                if (_patrimoineList != null)
                {
                    List<Patrimoine> entities = (from e in _patrimoineList
                                               where e.NomDuBien.Contains(_searchText)
                                               select e).ToList<Patrimoine>();
                    if (entities != null && entities.Any())
                    {
                        theCollection = new List<Patrimoine>(entities);
                    }
                    else
                    {

                    }
                }

                return theCollection;
            }
            set
            {
                _patrimoineList = value;
                NotifyPropertyChanged("PatrimoineList");
            }
        }



        private string _searchText = string.Empty;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value) { _searchText = value ?? string.Empty; NotifyPropertyChanged("SearchText"); }

                if (SearchCommand.CanExecute(null))
                {
                    SearchCommand.Execute(null);
                }
            }
        }



        private Command _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                _searchCommand = _searchCommand ?? new Command(DoSearchCommand, CanExecuteSearchCommand);
                return _searchCommand;
            }
        }
        private void DoSearchCommand()
        {
            // Refresh the list, which will automatically apply the search text
            NotifyPropertyChanged("PatrimoineList");
        }
        private bool CanExecuteSearchCommand()
        {
            return true;
        }





    }
}
