using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Models
{
    public class StudioModel
    {
        public long StudioNumber { get; set; }
        [Required(ErrorMessage = "Studio Name is Required!")]
        [Display(Name = "Studio Name")]
        public string StudioName { get; set; }
    }
}
