using MapReduceIndexes.Models;
using Raven.Client.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapReduceIndexes.Indexes
{
    public class Products_ByCategory : AbstractIndexCreationTask<Product, Products_ByCategory.Result>
    {
        public class Result
        {
            public string Category { get; set; }
            public int Count { get; set; }
        }

        public Products_ByCategory()
        {
            Map = products =>
                from product in products
                let categoryName = LoadDocument<Category>(product.Category).Name
                select new
                {
                    Category = product.Category,
                    Count = 1
                };

            Reduce = results =>
                from result in results
                group result by result.Category into g
                select new
                {
                    Category = g.Key,
                    Count = g.Sum(x => x.Count)
                };
        }
    }
}
