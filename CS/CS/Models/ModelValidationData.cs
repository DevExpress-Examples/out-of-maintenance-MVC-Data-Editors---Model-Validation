using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CS.Models {
    public class ModelValidationData {
        [Display(Name = "Name:")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Age:")]
        [Range(18, 100, ErrorMessage = "Must be between 18 and 100")]
        public int? Age { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Display(Name = "Arrival Date:")]
        [Required(ErrorMessage = "Arrival date is required")]
        public DateTime? ArrivalDate { get; set; }
    }
}