using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Controls.Examples.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Display(Name = "My name")]
        public string Name { get; set; }
        [Display(Name = "Street Address")]
        public string Address { get; set; }
        
        public List<Product> Products { get; set; }

        public Store() { this.Products = new List<Product>(); }
    }
}
