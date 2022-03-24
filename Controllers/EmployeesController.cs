using MapReduceIndexes.Indexes;
using MapReduceIndexes.Models;
using Raven.Client;
using System;
using System.Linq;

namespace MapReduceIndexes.Controllers
{
    public class EmployeesController
    {
        public static void GetEmployeesBySalesPerMonth()
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var query = session
                    .Query<Employees_BySalesPerMonth.Result, Employees_BySalesPerMonth>()
                    .Include(x => x.Employee);

                var results = (
                    from result in query
                    where result.Month == "1998-03"
                    orderby result.TotalSales descending
                    select result
                    ).ToList();

                foreach (var result in results)
                {
                    var employee = session.Load<Employee>(result.Employee);
                    Console.WriteLine(

                        $"{employee.FirstName} {employee.LastName})"
                        + $" made {result.TotalSales} sales.");
                }
            }
        }
            
    }
}
