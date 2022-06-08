using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Models
{
    public class LoanModel
    {
        public long LoanNumber { get; set; }
        public long LoanTypeNumber { get; set; }
        public long CopyNumber { get; set; }
        public long MemberNumber { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DateReturned { get; set; }
        public List<SelectListItem> LoanTypeList { get; set; }
        public List<SelectListItem> DVDCopyList { get; set; }
        public List<SelectListItem> MemberList { get; set; }
        public string LoanType { get; set; }
        public string Member { get; set; }
    }
}
