using AdventureWorksDatabase;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace WPF.ViewModel
{
    public class HumanResourcesViewModel : BaseViewModel
    {

        private static HumanResourcesViewModel instance;
        public static HumanResourcesViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HumanResourcesViewModel();
                }
                return instance;
            }
        }

        #region Fields
        private EmployeeDepartmentHistory selectedDepartmentHistory;
        private ObservableCollection<EmployeeDepartmentHistory> employeeDepartmentHistory;
        private ObservableCollection<Employee> employees;
        private ObservableCollection<Department> departments;
        private ObservableCollection<Shift> shifts;
        #endregion

        #region Properties
        public ObservableCollection<EmployeeDepartmentHistory> EmployeeDepartmentHistory
        {
            get
            {
                return UpdateEmployeeDepartmentHistory();
            }
            set
            {
                employeeDepartmentHistory = value;
                NotifyPropertyChanged("EmployeeDepartmentHistory");
            }
        }

        public EmployeeDepartmentHistory SelectedDepartmentHistory
        {
            get
            {
                return selectedDepartmentHistory;
            }
            set
            {
                selectedDepartmentHistory = value;
                NotifyUpdateLists();
                NotifyPropertyChanged("SelectedDepartmentHistory");
            }
        }

        public ObservableCollection<Employee> Employees
        {
            get
            {
                return updateEmployees();
            }
            set
            {
                employees = value;
                NotifyPropertyChanged("Employees");
            }
        }

        public ObservableCollection<Department> Departments
        {
            get
            {
                return UpdateDepartments();
            }
            set
            {
                this.departments = value;
                NotifyPropertyChanged("Departments");
            }
        }

        public ObservableCollection<Shift> Shifts
        {
            get
            {
                return UpdateShifts();
            }
            set
            {
                this.shifts = value;
                NotifyPropertyChanged("Shifts");
            }
        }
        #endregion

        public HumanResourcesViewModel()
        {

        }

        public ObservableCollection<Employee> updateEmployees()
        {
            return LinqQueries.GetEmployees(SelectedDepartmentHistory);

        }

        public ObservableCollection<Shift> UpdateShifts()
        {
            return LinqQueries.GetShifts(SelectedDepartmentHistory);

        }

        public ObservableCollection<Department> UpdateDepartments()
        {
           return LinqQueries.GetDepartments(SelectedDepartmentHistory);
        }

        public ObservableCollection<EmployeeDepartmentHistory> UpdateEmployeeDepartmentHistory()
        {
            return LinqQueries.GetEmployeeDepartmentHistory();
        }

        public void RefreshEmployeeDepartmentHistoryList()
        {
            //EmployeeDepartmentHistory = UpdateEmployeeDepartmentHistory();
            CollectionViewSource.GetDefaultView(EmployeeDepartmentHistory).Refresh();
            NotifyPropertyChanged("EmployeeDepartmentHistory");
        }

        public void NotifyUpdateLists()
        {
            NotifyPropertyChanged("Employees");
            NotifyPropertyChanged("Departments");
            NotifyPropertyChanged("Shifts");
        }

    }
}
