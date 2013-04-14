using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Controls.Examples.Models
{
    public class Person
    {
        [Key]
        [Editable(false)]
        public int PersonId { get; set; }

        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 4)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 4)]
        public string LastName { get; set; }
        
        public City City { get; set; }
    }
}
