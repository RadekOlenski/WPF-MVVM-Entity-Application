using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksDatabase
{
    public static class DataService
    {
        public static void AddEmployeeDepartmentHistoryEntity(EmployeeDepartmentHistory employeeDepartmentHistory)
        {
            using (AdventureWorksContext db = new AdventureWorksContext())
            {

                db.EmployeeDepartmentHistories.Add(employeeDepartmentHistory);
                try
                {
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                    db.Dispose();
                    throw new Exception("Błędne dane obiektu!!");
                }
            }
        }
    }
}
