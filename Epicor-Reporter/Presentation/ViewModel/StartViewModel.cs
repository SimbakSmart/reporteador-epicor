

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Presentation.UC;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using MenuItem = Presentation.Helpers.MenuItem;
namespace Presentation.ViewModel
{
    public  class StartViewModel:ViewModelBase
    {
        private bool isOpen;
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                RaisePropertyChanged(nameof(IsOpen));
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private ObservableCollection<MenuItem> menuOptions;

        public ObservableCollection<MenuItem> MenuOptions
        {
            get { return menuOptions; }
            set
            {
                menuOptions = value;
                RaisePropertyChanged(nameof(MenuOptions));
            }
        }

        private UserControl selectedUserControl;

        public UserControl SelectedUserControl
        {
            get { return selectedUserControl; }
            set
            {
                selectedUserControl = value;
                RaisePropertyChanged(nameof(SelectedUserControl));
            }
        }

        private MenuItem selectedItem;
        public MenuItem SelectedItem
        {
            get { return selectedItem; }
            set
            {

                selectedItem = value; 
                RaisePropertyChanged(nameof(SelectedItem));

                if (selectedItem != null)
                {
                    Title = selectedItem.Title;
                    IsOpen = false;
                    SelectedUserControl = (UserControl)Activator.CreateInstance(selectedItem.UserControlType);
                }


            }
        }


        public ICommand ToggleCommand { get; private set; }

        public StartViewModel()
        {
            IsOpen = false;
            Title = "ANÁLISIS DE REPORTES";
            MenuLinks();
            ToggleCommand = new RelayCommand(ToggleMenu);
        }

      
        private void ToggleMenu()
        {
            IsOpen = IsOpen ? true : false;
        }

        private void MenuLinks()
        {
            MenuOptions = new ObservableCollection<MenuItem>()
            {
               new MenuItem("Supporcalls in queues","Phone","SUPPORT CALLS IN QUEUES",typeof(CallInQueueView)),
               new MenuItem("Reporte de waiting for parts","BriefcaseVariantOutline","REPORTE DE WAITING FOR PARTS",typeof(ReportForPartsView)),
            };
            SelectedItem = MenuOptions[0];
        }

    }
}
