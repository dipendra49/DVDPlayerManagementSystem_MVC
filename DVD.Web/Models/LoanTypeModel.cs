using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Models
{
    public class LoanTypeModel
    {
        public long LoanTypeNumber { get; set; }
        [Required(ErrorMessage = "Loan Type is Required!")]
        [Display(Name = "Loan Type")]
        public string LoanType { get; set; }
        [Required(ErrorMessage = "Loan Duration is Required!")]
        [Display(Name = "Loan Duration")]
        public DateTime LoanDuration { get; set; }
    }
}
