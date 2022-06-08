using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.EntityModel
{
    public class MembershipCategory
    {
        [Key]
        public long MembershipCategoryNumber { get; set; }
        public string MembershipCategoryDescription { get; set; }
        public decimal MembershipCategoryTotalLoans { get; set; }
    }
}
