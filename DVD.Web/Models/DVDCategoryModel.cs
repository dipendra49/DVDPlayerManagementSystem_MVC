using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Models
{
    public class DVDCategoryModel
    {
        public long CategoryNumber { get; set; }
        [Required(ErrorMessage = "Category Description is Required!")]
        [Display(Name = "CategoryDescription")]
        public string CategoryDescription { get; set; }
        [Required(ErrorMessage = "Age Restricted is Required!")]
        [Display(Name = "Age Restricted")]
        public int AgeRestricted { get; set; }
    }
}
