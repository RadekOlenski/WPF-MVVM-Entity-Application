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
    public class EditRecordWindowViewModel
    {
        public event Action<EmployeeDepartmentHistory> Closed;
        public EditRecordWindowViewModel()
        {

        }

        public void Show(EmployeeDepartmentHistory selectedRecord)
        {
            EditRecordViewModel vm = new EditRecordViewModel(selectedRecord);
            vm.Closed += ChildWindow_Closed;
            ChildWindowManager.Instance.ShowChildWindow(new EditRecordView() { DataContext = vm });
        }

        void ChildWindow_Closed(EmployeeDepartmentHistory employeeDepartmentHistory)
        {
            if (Closed != null)
                Closed(employeeDepartmentHistory);
            ChildWindowManager.Instance.CloseChildWindow();
        }
    }
}
