using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Rg.Plugins.Popup.Services;
using SaveAll.Helpers;
using SaveAll.Interfaces;
using SaveAll.Model;
using SaveAll.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SaveAll.ViewModel.ViewModelPatrimoine
{
    public class EnregistrementPatrimoineViewModel : BasePatrimoineViewModel
    {
        public ICommand EnregistrementCommand { get; private set; }
        public ICommand AnnulerCommand { get; private set; }
        public ICommand SelectImagesCommand { get; private set; }


       

        public EnregistrementPatrimoineViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _patrimoine = new Patrimoine();
            _typePatrimoine = new TypePatrimoine();

            

            _multiMediaPickerService = DependencyService.Get<IMultiMediaPickerService>();

            EnregistrementCommand = new Command(async () => await EnregistrementDuBien());
            AnnulerCommand = new Command(async () => await Annuler());


            SelectImagesCommand = new Command(async (obj) =>
            {
                var hasPermission = await CheckPermissionsAsync();
                if (hasPermission)
                {
                    Media = new ObservableCollection<Patrimoine>();
                   await _multiMediaPickerService.PickPhotosAsync();
                   
                }
            });

            _multiMediaPickerService.OnMediaPicked += (s, a) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Media.Add(a);
                    
                });


            };

            FetchTypePatrimoine();
        }


        /// <summary>
        /// Afficher la liste de tous les types patrimoines
        /// </summary>
        /// <returns></returns>
        async Task FetchTypePatrimoine()
        {
            TypePatrimoineList = await new DatabaseHelper().TousLesTypesPatrimoines();
        }

        async Task<bool> CheckPermissionsAsync()
        {
            var retVal = false;
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                    {
                        await Application.Current.MainPage.DisplayAlert("Alert", "Need Storage permission to access to your photos.", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] {Permission.Storage });
                    status = results[Permission.Storage];
                }

                if (status == PermissionStatus.Granted)
                {
                    retVal = true;

                }
                else if (status != PermissionStatus.Unknown)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Permission Denied. Can not continue, try again.", "Ok");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                await Application.Current.MainPage.DisplayAlert("Alert", "Error. Can not continue, try again.", "Ok");
            }

            return retVal;

        }


        /// <summary>
        /// Enregistrer les documents utilisateur
        /// </summary>
        /// <returns></returns>

        async Task EnregistrementDuBien()
        {
 
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert(Messages.MessageEnregistrement, Messages.MessageValidation, "Enregistrer", "Annuler");

                if (isUserAccept)
                {
                    _patrimoine.EnregistrerEnBase();
                    var lebien = new DatabaseHelper().TousLePatrimoine().GetAwaiter().GetResult();
                    var bien = lebien.FindLast(p => p.NomDuBien != null);
                    if (App.MembreActuel == null)
                    {
                        App.MembreActuel = App.user;

                    }

                    App.MembreActuel.AttribuerPatrimoine(bien);

                    await Application.Current.MainPage.DisplayAlert(Messages.MessageSucces, Messages.MessageOk, "OK");


                    await PopupNavigation.Instance.PopAsync();

                MessagingCenter.Send<App>((App)Application.Current, "ActualiserListe");
            }
            
           
        }


        /// <summary>
        /// Annuler la procedure enregistrement
        /// </summary>
        /// <returns></returns>

        async Task Annuler()
        {
            await PopupNavigation.Instance.PopAsync();
        }

    


        // public string SelectedItemPicker
        // {
        //     get => _typeDocument.SelectedItemPicker;
        //     set
        //     {
        //         var typ = _typedocumentList.FirstOrDefault(p => p.SelectedItemPicker == value);
        //         _document.AffecterTypeDocumentAsync(typ);
        //         NotifyPropertyChanged("SelectedItemPicker");
        //     }
        // }
    }
}
