using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class Request
    {
        public int ID { get; set; }

        [Display(Name = "First Name"), Required]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DOB { get; set; }

        [Display(Name = "Phone Number"), Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "Catalog Year"), Required]
        public DateTime CatalogYear { get; set; }

        [Display(Name = "V#"), Required]
        public string VNumber { get; set; }

        [Display(Name = "Email"), Required]
        public string Email { get; set; }

        [Display(Name = "Major"), Required]
        public string Major { get; set; }

        [Display(Name = "Minor"), Required]
        public string Minor { get; set; }

        [Display(Name = "Advisor"), Required]
        public string Advisor { get; set; }
    }
}