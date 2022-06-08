using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Models
{
    public class DVDCopyModel
    {
        public long CopyNumber { get; set; }
        [Required]
        public long DVDNumber { get; set; }
        [Required]
        public DateTime DatePurchased { get; set; }
        public List<SelectListItem> DVDTitleList { get; set; }
    }
}
