using AdventureWorksDatabase;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace WPF.ViewModel
{
    public class AddEmployeeDepartmentHistoryViewModel : BaseViewModel
    {
        public event Action<EmployeeDepartmentHistory> Closed;

        public AddEmployeeDepartmentHistoryViewModel()
        {
            saveCommand = new RelayCommand(() => SaveHistoryEntry());
            cancelCommand = new RelayCommand(() => CloseWindow());
        }

        #region Fields
        private int businessEntityID;
        private short departmentID;
        private DateTime startDate;
        private byte shiftID;
        private DateTime? endDate;
        #endregion

        #region Properties
        public string ErrorMessage { get; set; }

        public int BusinessEntityID
        {
            get
            {
                return businessEntityID;
            }
            set
            {
                businessEntityID = value;
                NotifyPropertyChanged("BusinessEntityID");
            }
        }

        public short DepartmentID
        {
            get { return departmentID; }
            set
            {
                departmentID = value;
                NotifyPropertyChanged("DepartmentID");
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                NotifyPropertyChanged("StartDate");
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

        public byte ShiftID
        {
            get { return shiftID; }
            set
            {
                shiftID = value;
                NotifyPropertyChanged("ShiftID");
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
                EmployeeDepartmentHistory newEntry = new EmployeeDepartmentHistory();
                {
                    newEntry.BusinessEntityID = BusinessEntityID;
                    newEntry.DepartmentID = DepartmentID;
                    newEntry.StartDate = StartDate;
                    newEntry.ShiftID = ShiftID;
                    newEntry.EndDate = EndDate;
                    newEntry.ModifiedDate = DateTime.Now;
                }
                try
                {
                    DataService.AddEmployeeDepartmentHistoryEntity(newEntry);
                    NotifyPropertyChanged("EmployeeDepartmentHistory");
                    //TODO jak wywołać funkcję z HumanResourcesViewModel aby odświeżyć listę ?????
                    Closed(newEntry);

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
