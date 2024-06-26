

using Core.Models;
using GalaSoft.MvvmLight;
using Infraestructure.Interfaces;
using Infraestructure.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.Windows;

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

        public CallInQueueViewModel()
        {
            TotalRecords = 669;
            service = new CallInQueuesProvider();

            Task.Run(async() => 
            { 
               await LoadDataAsync();
            });
        }

        public async Task LoadDataAsync()
        {
            try
            {
                var list = await service.FetchAllAsync();
                CallItemList = new ObservableCollection<CallInQueues>(list);

                TotalRecords = await service.FetchCountAsync();
            }
            catch (Exception ex)
            {
                  MessageBox.Show(ex.Message);
            }
        }
    }
}
