using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MultiSelectExample.Models
{
    public class Profile
    {
        [Key]
        public int ProfileID { get; set; }
        
       
        public string ProfilerName { get; set; }
        
        public string ProfilerNumber { get; set; }

        [Display(Name ="Select Category")]
        public string CategoryID { get; set; }
    }
}