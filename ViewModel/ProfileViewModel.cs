using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultiSelectExample.ViewModel
{
    public class ProfileViewModel
    {
        [Key]
        public int ProfileID { get; set; }
        [Display(Name = "Enter Your Name")]
        [Required(ErrorMessage ="Name is required")]
        public string ProfilerName { get; set; }
        [Display(Name = "Enter Your Phone Number")]
        [MaxLength(10, ErrorMessage = "Must Be 10 Chaaracters long")]
        [MinLength(10, ErrorMessage = "Must Be 10 Chaaracters long")]
        [Required(ErrorMessage = "Number is required")]
        public string ProfilerNumber { get; set; }
        public List<int> CategoryID { get; set; }
    }
}