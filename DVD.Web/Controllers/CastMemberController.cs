using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Controllers
{
    public class CastMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
