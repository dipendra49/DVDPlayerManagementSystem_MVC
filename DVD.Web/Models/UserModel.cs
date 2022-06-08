using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Models
{
    public class UserModel
    {
        public long UserNumber { get; set; }
        [Required(ErrorMessage = "User Name is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User Type is required")]
        public string UserType { get; set; }
        [Required(ErrorMessage = "User Password is required!")]
        public string UserPassword { get; set; }
        public List<SelectListItem> UserTypeList { get; set; }
    }
}
