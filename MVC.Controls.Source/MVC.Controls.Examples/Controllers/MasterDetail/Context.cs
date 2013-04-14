using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Controls.Examples.Models;

namespace MVC.Controls.Examples.Controllers.MasterDetail
{
    public class Context : IDisposable
    {
        private static Context _singleton = new Context();

        protected Context()
        {
            Stores = new List<Store> 
            { 
                new Store { 
                    StoreId=1,
                    Name="Video Store A", 
                    Address="High Street",
                    Products=new List<Product>
                    {
                        new Product{ProductId=1, CompanyName="A", Name="Piracy on the high seas", Price=15},
                        new Product{ProductId=2, CompanyName="B", Name="Piracy on the low seas", Price=25},
                        new Product{ProductId=3, CompanyName="C", Name="Piracy on the mid seas", Price=17.5},
                    }},

                new Store { 
                    StoreId=2,
                    Name="Video Store B", 
                    Address="Mid Street",
                    Products=new List<Product>
                    {
                        new Product{ProductId=1, CompanyName="A", Name="Thieving on the high seas", Price=150},
                        new Product{ProductId=2, CompanyName="B", Name="Thieving on the low seas", Price=250},
                        new Product{ProductId=3, CompanyName="C", Name="Thieving on the mid seas", Price=17.50},
                    }},

                     new Store { 
                    StoreId=3,
                    Name="Video Store C", 
                    Address="Low Street",
                    Products=new List<Product>
                    {
                        new Product{ProductId=1, CompanyName="A", Name="Frollicing on the high seas", Price=1.5},
                        new Product{ProductId=2, CompanyName="B", Name="Frollicing on the low seas", Price=2.5},
                        new Product{ProductId=3, CompanyName="C", Name="Frollicing on the mid seas", Price=1.75},
                    }},
            };
        }

        public static Context Singleton { get { return _singleton; } }

        public List<Store> Stores { get; set; }

        public void Dispose()
        {
            // Just to make it disposable, as any real context would be
        }
    }
}