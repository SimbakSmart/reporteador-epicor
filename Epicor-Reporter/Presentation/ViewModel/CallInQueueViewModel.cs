

using Core.Models;
using GalaSoft.MvvmLight;
using Infraestructure.Interfaces;
using Infraestructure.Services;
using Presentation.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
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



        public ICommand SearchCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public CallInQueueViewModel()
        {
            TotalRecords = 0;
            IsLoading = false;
            service = new CallInQueuesProvider();
            SearchCommand = new AsyncRelayCommand(SearchAsync);
            RefreshCommand = new AsyncRelayCommand(RefrehAsync);

            Task.Run(async() => 
            { 
               await LoadDataAsync();
            });
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
                  MessageBox.Show(ex.Message);
            }
            finally
            {
                IsLoading=false;
            }
        }

        public async Task SearchAsync()
        {
            try
            {
                IsLoading = true;
                string searchBy = $" AND Sc.Number LIKE '%{SearchTerm}%'  OR Que.Name LIKE '%{SearchTerm}%' ";
                var list = await service.FetchAllAsync(50,0,searchBy);
                TotalRecords = await service.FetchCountAsync(searchBy);
                CallItemList = new ObservableCollection<CallInQueues>(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
