

using Core.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Infraestructure.Interfaces;
using Infraestructure.Services;
using Notifications.Wpf;
using Presentation.Helpers;
using Presentation.UC;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public  class CallInQueueViewModel : ViewModelBase
    {

        ICallInQueuesProvider service;

        private ObservableCollection<CallInQueues> callItemList;

        public ObservableCollection<CallInQueues> CallItemList
        {
            get { return callItemList; }
            set
            {
                callItemList = value;
                RaisePropertyChanged(nameof(CallItemList));
            }
        }

        private int totalRecords;

        public int TotalRecords
        {
            get { return totalRecords; }

            set
            {
                totalRecords = value;
                RaisePropertyChanged(nameof(TotalRecords));
            }
        }

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }

            set
            {
                isLoading = value;
                RaisePropertyChanged(nameof(IsLoading));
            }
        }


        private  string searchTerm;

        public string SearchTerm
        {
            get { return searchTerm; }

            set
            {
                searchTerm = value;
                RaisePropertyChanged(nameof(SearchTerm));
            }
        }

        private DateTime? searchByOpenDate;

        public DateTime? SearchByOpenDate
        {
            get { return searchByOpenDate; }

            set
            {
                searchByOpenDate = value;
                RaisePropertyChanged(nameof(SearchByOpenDate));
            }
        }

        private CallInQueues selectedItem;

        public CallInQueues SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; RaisePropertyChanged(nameof(SelectedItem)); }
        }


        public ICommand SearchCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public ICommand SearchByDateCommand { get; private set; }

        public ICommand SendIDCommand { get; private set; }
        public CallInQueueViewModel()
        {
            TotalRecords = 0;
            IsLoading = false;
            SearchByOpenDate = DateTime.UtcNow;
            service = new CallInQueuesProvider();
            SearchCommand = new AsyncRelayCommand(SearchAsync);
            RefreshCommand = new AsyncRelayCommand(RefrehAsync);
            SearchByDateCommand = new AsyncRelayCommand(SearchByDateAsync);
            SendIDCommand = new RelayCommand<string>(AttributeDetailsAsync);



            Task.Run(async() => 
            { 
               await LoadDataAsync();
            });
        }

        private async void AttributeDetailsAsync(string id)
        {

            try
            {
                var queryIdPara = $"  ParentID='{id}' ";
                var list = await service.FetchAttributesAsync(queryIdPara);

                var dialog = new AttributeDialog(list);

                await MaterialDesignThemes.Wpf.DialogHost.Show(dialog);
                NotifiactionHelper
                   .SetMessage("Información", "La búsqueda se ha realizado con éxito.",
                           NotificationType.Success);
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message.ToString());
                NotifiactionHelper
              .SetMessage("Error", ex.Message.ToString(),
                         NotificationType.Error);
            }


        }

        public async Task LoadDataAsync()
        {
            try
            {
                IsLoading = true;
                var list = await service.FetchAllAsync(50, 0, string.Empty);
                CallItemList = new ObservableCollection<CallInQueues>(list);

                TotalRecords = await service.FetchCountAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                NotifiactionHelper
              .SetMessage("Error", ex.Message.ToString(),
                         NotificationType.Error);
            }
            finally
            {
                IsLoading=false;
            }
        }

        public async Task SearchAsync()
        {

            if (string.IsNullOrEmpty(SearchTerm) ||
               string.IsNullOrWhiteSpace(SearchTerm))
            {
                NotifiactionHelper
                .SetMessage("No Valido", "Es necesario ingresar un valor de busqueda",
                           NotificationType.Error);
                return;
            }

            try
            {
                IsLoading = true;
                string searchBy =  $" AND Sc.Number LIKE '%{SearchTerm}%'  " +
                                   $" OR Que.Name LIKE '%{SearchTerm}%' " +
                                   //$" OR  Types LIKE '%{SearchTerm}%' ";
                                   $" OR  Sc.Summary  LIKE '%{SearchTerm}%' " +
                                   $" OR  Status.Name LIKE '%{SearchTerm}%' "+
                                   $" OR  Pri.Description  LIKE '%{SearchTerm}%' ";
                var list = await service.FetchAllAsync(50,0,searchBy);
                TotalRecords = await service.FetchCountAsync(searchBy);
                CallItemList = new ObservableCollection<CallInQueues>(list);


                NotifiactionHelper
                .SetMessage("Información", "La búsqueda se ha realizado con éxito.",
                        NotificationType.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                NotifiactionHelper
              .SetMessage("Error", ex.Message.ToString(),
                         NotificationType.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        public async Task SearchByDateAsync()
        {
            try
            {
                IsLoading = true;
                string searchBy = $" AND OpenDate = {SearchByOpenDate.Value}";
                var list = await service.FetchAllAsync(50, 0, searchBy);
                TotalRecords = await service.FetchCountAsync(searchBy);
                CallItemList = new ObservableCollection<CallInQueues>(list);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                NotifiactionHelper
              .SetMessage("Error", ex.Message.ToString(),
                         NotificationType.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }
        public async Task RefrehAsync()
        {
            try
            {
                await LoadDataAsync();
                SearchTerm = string.Empty;

                NotifiactionHelper
               .SetMessage("Información", "Filtors recargados con exito.",
                       NotificationType.Success);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                NotifiactionHelper
              .SetMessage("Error", ex.Message.ToString(),
                         NotificationType.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
