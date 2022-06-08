using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.EntityModel
{
    public class LoanTypes
    {
        [Key]
        public long LoanTypeNumber { get; set; }
        public string LoanType { get; set; }
        public DateTime LoanDuration { get; set; }
    }
}
