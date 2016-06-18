using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using WPF.Common;

namespace WPF.ViewModel
{
    
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            ShowAddEmployeeDepartmentHistoryWindowCommand = new RelayCommand(() => ShowAddEmployeeDepartmentHistoryWindow());
        }

        #region Commands
        private ICommand showAddEmployeeDepartmentHistoryWindowCommand;

        public ICommand ShowAddEmployeeDepartmentHistoryWindowCommand
        {
            get { return showAddEmployeeDepartmentHistoryWindowCommand; }
            set { showAddEmployeeDepartmentHistoryWindowCommand = value; }
        }
        #endregion
      

        public void ShowAddEmployeeDepartmentHistoryWindow()
        {
            AddHistoryWindowViewModel addHistoryWindow = new AddHistoryWindowViewModel();
            addHistoryWindow.Show();
        }
    }
}