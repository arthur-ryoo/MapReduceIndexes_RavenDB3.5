using MapReduceIndexes.Models;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapReduceIndexes.Indexes
{
    public class Employees_BySalesPerMonth :
        AbstractIndexCreationTask<Order, Employees_BySalesPerMonth.Result>
    {
        public class Result
        {
            public string Employee { get; set; }
            public string Month { get; set; }
            public int TotalSales { get; set; }
        }

        public Employees_BySalesPerMonth()
        {
            Map = orders =>
                from order in orders
                select new
                {
                    order.Employee,
                    Month = order.OrderedAt.ToString("yyyy-MM"),
                    TotalSales = 1
                };

            Reduce = results =>
                from result in results
                group result by new
                {
                    result.Employee,
                    result.Month
                }
                into g
                select new
                {
                    g.Key.Employee,
                    g.Key.Month,
                    TotalSales = g.Sum(x => x.TotalSales)
                };
        }
    }
}
