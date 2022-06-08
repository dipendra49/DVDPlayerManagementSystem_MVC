using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Models
{
    public class ActorModel
    {
        public long ActorNumber { get; set; }
        [Required(ErrorMessage = "Actor Surname is Required!")]
        [Display(Name = "Actor Surname")]
        public string ActorSurname { get; set; }
        [Required(ErrorMessage = "Actor First Name is Required!")]
        [Display(Name = "Actor First Name")]
        public string ActorFirstName { get; set; }
    }
}
