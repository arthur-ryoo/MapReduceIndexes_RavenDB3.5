using MapReduceIndexes.Indexes;
using System;
using System.Linq;

namespace MapReduceIndexes.Controllers
{
    public class ProductsController
    {
        public static void GetProductsByCategory()
        {
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var results = session
                    .Query<Products_ByCategory.Result, Products_ByCategory>()
                    //.Include(x => x.Category)
                    .ToList();

                foreach (var result in results)
                {
                    //var category = session.Load<Category>(result.Category);
                    //Console.WriteLine($"{category.Name} has {result.Count} items.");
                    Console.WriteLine($"{result.Category} has {result.Count} items.");
                }
            }
        }

    }
}
