using AdventureWorksDatabase;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.ViewModel
{
    public class EditRecordViewModel : BaseViewModel
    {
        public event Action<EmployeeDepartmentHistory> Closed;

        public EditRecordViewModel(EmployeeDepartmentHistory selectedRecord)
        {
            this.selectedRecord = selectedRecord;
            saveCommand = new RelayCommand(() => SaveHistoryEntry());
            cancelCommand = new RelayCommand(() => CloseWindow());
            UpdateProperties();
        }

        private void UpdateProperties()
        {
            this.EndDate = selectedRecord.EndDate;
        }

        #region Fields
        private EmployeeDepartmentHistory selectedRecord;
        private DateTime? endDate;
        #endregion

        #region Properties
        public string ErrorMessage { get; set; }

        public EmployeeDepartmentHistory SelectedRecord
        {
            get
            {
                return selectedRecord;
            }
            set
            {
                selectedRecord = value;
                NotifyPropertyChanged("SelectedRecord");
            }

        }

        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                NotifyPropertyChanged("EndDate");
            }
        }

        #endregion

        #region Commands
        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get { return saveCommand; }

        }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get { return cancelCommand; }

        }
        #endregion

        #region Command Methods
        private void SaveHistoryEntry()
        {
            if (Closed != null)
            {
                    selectedRecord.EndDate = EndDate;
                    selectedRecord.ModifiedDate = DateTime.Now;
                try
                {
                    DataService.EditEmployeeDepartmentHistoryEntity(selectedRecord);
                    NotifyPropertyChanged("EmployeeDepartmentHistory");
                    HumanResourcesViewModel.Instance.RefreshEmployeeDepartmentHistoryList();
                    Closed(selectedRecord);

                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                    NotifyPropertyChanged("ErrorMessage");
                }

            }
        }

        private void CloseWindow()
        {
            Closed(new EmployeeDepartmentHistory());
        }
        #endregion
    }
}
