using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.EntityModel
{
    public class Member
    {
        [Key]
        public long MemberNumber { get; set; }
        public long MembershipCategoryNumber { get; set; }
        public string MemberLastName { get; set; }
        public string MemberFirstName { get; set; }
        public string MemberAddress { get; set; }
        public DateTime MemberDOB { get; set; }
    }
}
