using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.EntityModel
{
    public class User
    {
        [Key]
        public long UserNumber { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string UserPassword { get; set; }
    }
}
