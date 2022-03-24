using MapReduceIndexes.Controllers;
using System;

namespace MapReduceIndexes
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductsController.GetProductsByCategory();

            EmployeesController.GetEmployeesBySalesPerMonth();

            Console.WriteLine("Hit enter to exit");
            Console.ReadLine();
        }
    }
}
