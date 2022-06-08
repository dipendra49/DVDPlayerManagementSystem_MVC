using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Models
{
    public class ProducerModel
    {
        public long ProducerNumber { get; set; }
        [Required(ErrorMessage = "Producer Name is Required!")]
        [Display(Name = "Producer Name")]
        public string ProducerName { get; set; }
    }
}
