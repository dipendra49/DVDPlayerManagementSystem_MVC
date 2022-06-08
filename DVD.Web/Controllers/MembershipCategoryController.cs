using DVD.Web.DbConnection;
using DVD.Web.EntityModel;
using DVD.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Controllers
{
    public class MembershipCategoryController : Controller
    {
        DVDContext _dbconnection;
        public MembershipCategoryController(DVDContext dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public ActionResult Index()
        {
            var list = _dbconnection.MembershipCategory.ToList();
            var lst = new List<MembershipCategoryModel>();
            foreach (var item in list)
            {
                var model = new MembershipCategoryModel();
                model.MembershipCategoryNumber = item.MembershipCategoryNumber;
                model.MembershipCategoryDescription = item.MembershipCategoryDescription;
                model.MembershipCategoryTotalLoans = item.MembershipCategoryTotalLoans;
                lst.Add(model);
            }
            return View(lst);
        }
        public ActionResult AddMembershipCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMembershipCategory(MembershipCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entitymodel = new MembershipCategory();
                entitymodel.MembershipCategoryDescription = model.MembershipCategoryDescription;
                entitymodel.MembershipCategoryTotalLoans = model.MembershipCategoryTotalLoans;
                var data = _dbconnection.Add<MembershipCategory>(entitymodel);
                _dbconnection.SaveChanges();
                return Redirect("/MembershipCategory/Index");
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return View(model);
            }
        }
        public ActionResult UpdateMembershipCategory()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.MembershipCategory.Where(x => x.MembershipCategoryNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    var model = new MembershipCategoryModel();
                    model.MembershipCategoryNumber = data.MembershipCategoryNumber;
                    model.MembershipCategoryDescription = data.MembershipCategoryDescription;
                    model.MembershipCategoryTotalLoans = data.MembershipCategoryTotalLoans;
                    return View(model);
                }
                else
                {
                    return Redirect("/MembershipCategory/Index");
                }
            }
            else
            {
                return Redirect("/MembershipCategory/Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMembershipCategory(MembershipCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _dbconnection.MembershipCategory.Where(x => x.MembershipCategoryNumber == model.MembershipCategoryNumber).FirstOrDefault();
                if (item != null)
                {
                    item.MembershipCategoryDescription = model.MembershipCategoryDescription;
                    item.MembershipCategoryTotalLoans = model.MembershipCategoryTotalLoans;
                    _dbconnection.SaveChanges();
                    return Redirect("/MembershipCategory/Index");
                }
                else
                {
                    ViewData["Error"] = "Membership Category not found!";
                    return Redirect("/MembershipCategory/UpdateMembershipCategory?id=" + model.MembershipCategoryNumber);
                }
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return Redirect("/MembershipCategory/UpdateMembershipCategory?id=" + model.MembershipCategoryNumber);
            }
        }
        public ActionResult DeleteMembershipCategory()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.MembershipCategory.Where(x => x.MembershipCategoryNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    _dbconnection.MembershipCategory.Remove(data);
                    _dbconnection.SaveChanges();
                    ViewData["Error"] = "Membership Category deleted successfully!";
                    return Redirect("/MembershipCategory/Index");
                }
                else
                {
                    ViewData["Error"] = "Membership Category Not found!";
                    return Redirect("/MembershipCategory/Index");
                }
            }
            else
            {
                ViewData["Error"] = "Membership Category Not found!";
                return Redirect("/MembershipCategory/Index");
            }
        }
    }
}
