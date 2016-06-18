using AdventureWorksDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Common;
using WPF.View;

namespace WPF.ViewModel
{
    class AddHistoryWindowViewModel : BaseViewModel
    {

        public event Action<EmployeeDepartmentHistory> Closed;
        public AddHistoryWindowViewModel()
        {

        }

        public void Show()
        {
            AddEmployeeDepartmentHistoryViewModel vm = new AddEmployeeDepartmentHistoryViewModel();
            vm.Closed += ChildWindow_Closed;
            ChildWindowManager.Instance.ShowChildWindow(new AddEmployeeDepartmentHistoryView() { DataContext = vm });
        }

        void ChildWindow_Closed(EmployeeDepartmentHistory employeeDepartmentHistory)
        {
            if (Closed != null)
                Closed(employeeDepartmentHistory);
            ChildWindowManager.Instance.CloseChildWindow();
        }
    }
}
