using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Models
{
    public class MembershipCategoryModel
    {
        public long MembershipCategoryNumber { get; set; }
        [Required(ErrorMessage = "Membership Category Description is Required!")]
        [Display(Name = "Membership Category Description")]
        public string MembershipCategoryDescription { get; set; }
        [Required(ErrorMessage = "Membership Category Total Loans is Required!")]
        [Display(Name = "Membership Category Total Loans")]
        public decimal MembershipCategoryTotalLoans { get; set; }
    }
}
