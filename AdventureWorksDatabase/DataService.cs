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

        public static void EditEmployeeDepartmentHistoryEntity(EmployeeDepartmentHistory employeeDepartmentHistory)
        {
            using (AdventureWorksContext db = new AdventureWorksContext())
            {
                db.Entry(employeeDepartmentHistory).State = System.Data.Entity.EntityState.Modified;
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

        public static void DeleteEmployeeDepartmentHistoryEntity(EmployeeDepartmentHistory selectedRecord)
        {
            using (AdventureWorksContext db = new AdventureWorksContext())
            {
                db.Entry(selectedRecord).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
