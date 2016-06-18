using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPF.ViewModel;
using System.Threading;
using System.Linq;

namespace ViewModelTests
{
    [TestClass]
    public class HumanResourcesViewModelTest
    {
        [TestMethod]
        public void TestEmployeeDepartmentHistoryListRefresh()
        {
            HumanResourcesViewModel vm = new HumanResourcesViewModel();

            Thread.Sleep(3000);
            Assert.IsTrue(vm.EmployeeDepartmentHistory.Count > 0);
        }

        [TestMethod]
        public void TestDepartmetsListRefresh()
        {
            HumanResourcesViewModel vm = new HumanResourcesViewModel();

            Thread.Sleep(3000);

            bool departmentsRefreshEventRaised = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Departments")
                {
                    departmentsRefreshEventRaised = true;
                }
            };
            vm.SelectedDepartmentHistory = vm.EmployeeDepartmentHistory.Skip(1).First();
            Assert.IsTrue(departmentsRefreshEventRaised);

            Thread.Sleep(3000);
            Assert.IsTrue(vm.Departments.Count > 0);
        }

        [TestMethod]
        public void TestShiftsListRefresh()
        {
            HumanResourcesViewModel vm = new HumanResourcesViewModel();

            Thread.Sleep(3000);

            bool shiftsRefreshEventRaised = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Shifts")
                {
                    shiftsRefreshEventRaised = true;
                }
            };
            vm.SelectedDepartmentHistory = vm.EmployeeDepartmentHistory.Skip(1).First();
            Assert.IsTrue(shiftsRefreshEventRaised);

            Thread.Sleep(3000);
            Assert.IsTrue(vm.Shifts.Count > 0);
        }

        [TestMethod]
        public void TestEmployeesListRefresh()
        {
            HumanResourcesViewModel vm = new HumanResourcesViewModel();

            Thread.Sleep(3000);

            bool employeesRefreshEventRaised = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Employees")
                {
                    employeesRefreshEventRaised = true;
                }
            };
            vm.SelectedDepartmentHistory = vm.EmployeeDepartmentHistory.Skip(1).First();
            Assert.IsTrue(employeesRefreshEventRaised);

            Thread.Sleep(3000);
            Assert.IsTrue(vm.Employees.Count > 0);
        }
    }
}
