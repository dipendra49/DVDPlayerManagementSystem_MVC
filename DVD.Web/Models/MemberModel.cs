using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Models
{
    public class MemberModel
    {
        public long MemberNumber { get; set; }
        [Required]
        public long MembershipCategoryNumber { get; set; }
        [Required]
        public string MemberLastName { get; set; }
        [Required]
        public string MemberFirstName { get; set; }
        [Required]
        public string MemberAddress { get; set; }
        [Required]
        public DateTime MemberDOB { get; set; }
        public List<SelectListItem> MembershipCategoryList { get; set; }
        public string MembershipCategoryDescription { get; set; }
    }
}
