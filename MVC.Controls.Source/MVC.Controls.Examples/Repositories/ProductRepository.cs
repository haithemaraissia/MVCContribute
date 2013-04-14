using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Controls.Examples.Models;

namespace MVC.Controls.Examples.Repositories
{
    public class ProductRepository
    {
        public List<Product> ListAll()
        {
            List<Product> result = new List<Product>();

            for (int i = 0; i < 20; i++)
            {
                Product p = new Product();
                p.Name = "Product " + i.ToString();
                p.ProductId = i;
                p.Price = i * 2.5;
                p.CompanyName = "Company " + (i % 5).ToString();
                result.Add(p);
            }

            return result;
        }
    }
}
