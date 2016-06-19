using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using WPF.Common;
using System;
using AdventureWorksDatabase;

namespace WPF.ViewModel
{

    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            ShowAddEmployeeDepartmentHistoryWindowCommand = new RelayCommand(() => ShowAddEmployeeDepartmentHistoryWindow());
            ShowEditRecordWindowCommand = new RelayCommand(() => ShowEditRecordWindow());
            DeleteRecordCommand = new RelayCommand(() => DeleteRecord());

        }

        #region Commands
        private ICommand showAddEmployeeDepartmentHistoryWindowCommand;

        public ICommand ShowAddEmployeeDepartmentHistoryWindowCommand
        {
            get { return showAddEmployeeDepartmentHistoryWindowCommand; }
            set { showAddEmployeeDepartmentHistoryWindowCommand = value; }
        }

        private ICommand showEditRecordWindowCommand;

        public ICommand ShowEditRecordWindowCommand
        {
            get { return showEditRecordWindowCommand; }
            set { showEditRecordWindowCommand = value; }
        }

        private ICommand deleteRecordCommand;

        public ICommand DeleteRecordCommand
        {
            get { return deleteRecordCommand; }
            set { deleteRecordCommand = value; }
        }
        #endregion


        public void ShowAddEmployeeDepartmentHistoryWindow()
        {
            AddHistoryWindowViewModel addHistoryWindow = new AddHistoryWindowViewModel();
            addHistoryWindow.Show();
        }

        private void ShowEditRecordWindow()
        {
            EmployeeDepartmentHistory selectedRecord = HumanResourcesViewModel.Instance.SelectedDepartmentHistory;
            if(selectedRecord != null)
            {
                EditRecordWindowViewModel editRecordWindow = new EditRecordWindowViewModel();
                editRecordWindow.Show(selectedRecord);
            }
        }

        private void DeleteRecord()
        {
            EmployeeDepartmentHistory selectedRecord = HumanResourcesViewModel.Instance.SelectedDepartmentHistory;
            if(selectedRecord != null)
            {
                DataService.DeleteEmployeeDepartmentHistoryEntity(selectedRecord);
                HumanResourcesViewModel.Instance.RefreshEmployeeDepartmentHistoryList();
            }
        }


    }
}