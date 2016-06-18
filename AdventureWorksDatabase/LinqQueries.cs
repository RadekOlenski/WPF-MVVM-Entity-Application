using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksDatabase
{
    public static class LinqQueries
    {
        public static ObservableCollection<Employee> GetEmployees(EmployeeDepartmentHistory selectedItem)
        {
            using (AdventureWorksContext db = new AdventureWorksContext())
            {
                if (selectedItem != null)
                {
                    List<Employee> query = (from e in db.Employees
                                            where selectedItem.BusinessEntityID == e.BusinessEntityID
                                            select e).ToList();

                    return new ObservableCollection<Employee>(query);
                }
                else return null;
            }
        }

        public static ObservableCollection<EmployeeDepartmentHistory> GetEmployeeDepartmentHistory()
        {
            using (AdventureWorksContext db = new AdventureWorksContext())
            {

                List<EmployeeDepartmentHistory> query = (from h in db.EmployeeDepartmentHistories
                                                         select h).ToList();

                //foreach (EmployeeDepartmentHistory item in query)
                //{
                //    List<Department> departments = (from d in db.Departments
                //                                    where item.DepartmentID == d.DepartmentID
                //                                    select d).ToList();
                //    List<Employee> employees = (from e in db.Employees
                //                                where item.BusinessEntityID == e.BusinessEntityID
                //                                select e).ToList();
                //    List<Shift> shifts = (from s in db.Shifts
                //                          where item.ShiftID == s.ShiftID
                //                          select s).ToList();
                //    item.Department = departments.First();
                //    item.Shift = shifts.First();
                //    item.Employee = employees.First();

                //}

                return new ObservableCollection<EmployeeDepartmentHistory>(query);
            }
        }

        public static ObservableCollection<Shift> GetShifts(EmployeeDepartmentHistory selectedItem)
        {
            using (AdventureWorksContext db = new AdventureWorksContext())
            {
                if (selectedItem != null)
                {
                    List<Shift> query = (from s in db.Shifts
                                         where selectedItem.ShiftID == s.ShiftID
                                         select s).ToList();

                    return new ObservableCollection<Shift>(query);
                }
                else return null;
            }
        }

        public static ObservableCollection<Department> GetDepartments(EmployeeDepartmentHistory selectedItem)
        {
            using (AdventureWorksContext db = new AdventureWorksContext())
            {
                if (selectedItem != null)
                {
                    List<Department> query = (from d in db.Departments
                                         where selectedItem.DepartmentID == d.DepartmentID
                                         select d).ToList();

                    return new ObservableCollection<Department>(query);
                }
                else return null;
            }
        }

    }
}
