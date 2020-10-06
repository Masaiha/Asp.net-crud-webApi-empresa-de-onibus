using System;
using System.Collections.Generic;

namespace Ubus.Business.Entities
{
    public class Product : Entity
    {
        public Guid MiniBarId { get; set; }
        public string Name { get; set; }
        public string brand { get; set; }
        public decimal Price { get; set; }

        //public IEnumerable<string> Products { get; set; }

        /* EF Relational */
        public MiniBar MiniBar { get; set; }

        //public Product()
        //{
        //    Products = new List<string>();
        //}

        //public void setProducts(string product)
        //{
        //    Products.(product);
        //}

        //public void setProducts(List<string> product)
        //{
        //    Products.AddRange(product);
        //}
    }
}
