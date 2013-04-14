using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Controls.Examples.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        [Display(Name="Company name")]
        public string CompanyName { get; set; }
        public double Price { get; set; }
        public List<Store> Stores { get; set; }

        public Product() { this.Stores = new List<Store>(); }
    }
}
