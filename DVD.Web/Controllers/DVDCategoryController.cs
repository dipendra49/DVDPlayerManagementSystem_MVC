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
    public class DVDCategoryController : Controller
    {
        DVDContext _dbconnection;
        public DVDCategoryController(DVDContext dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public ActionResult Index()
        {
            var list = _dbconnection.DVDCategory.ToList();
            var lst = new List<DVDCategoryModel>();
            foreach (var item in list)
            {
                var model = new DVDCategoryModel();
                model.CategoryNumber = item.CategoryNumber;
                model.CategoryDescription = item.CategoryDescription;
                model.AgeRestricted = item.AgeRestricted;
                lst.Add(model);
            }
            return View(lst);
        }
        public ActionResult AddDVDCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDVDCategory(DVDCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entitymodel = new DVDCategory();
                entitymodel.CategoryDescription = model.CategoryDescription;
                entitymodel.AgeRestricted = model.AgeRestricted;
                var data = _dbconnection.Add<DVDCategory>(entitymodel);
                _dbconnection.SaveChanges();
                return Redirect("/DVDCategory/Index");
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return View(model);
            }
        }
        public ActionResult UpdateDVDCategory()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.DVDCategory.Where(x => x.CategoryNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    var model = new DVDCategoryModel();
                    model.CategoryNumber = data.CategoryNumber;
                    model.CategoryDescription = data.CategoryDescription;
                    model.AgeRestricted = data.AgeRestricted;
                    return View(model);
                }
                else
                {
                    return Redirect("/DVDCategory/Index");
                }
            }
            else
            {
                return Redirect("/DVDCategory/Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDVDCategory(DVDCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _dbconnection.DVDCategory.Where(x => x.CategoryNumber == model.CategoryNumber).FirstOrDefault();
                if (item != null)
                {
                    item.CategoryDescription = model.CategoryDescription;
                    item.AgeRestricted = model.AgeRestricted;
                    _dbconnection.SaveChanges();
                    return Redirect("/DVDCategory/Index");
                }
                else
                {
                    ViewData["Error"] = "DVD Category not found!";
                    return Redirect("/DVDCategory/UpdateDVDCategory?id=" + model.CategoryNumber);
                }
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return Redirect("/DVDCategory/UpdateDVDCategory?id=" + model.CategoryNumber);
            }
        }
        public ActionResult DeleteDVDCategory()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.DVDCategory.Where(x => x.CategoryNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    _dbconnection.DVDCategory.Remove(data);
                    _dbconnection.SaveChanges();
                    ViewData["Error"] = "DVD Category deleted successfully!";
                    return Redirect("/DVDCategory/Index");
                }
                else
                {
                    ViewData["Error"] = "DVD Category Not found!";
                    return Redirect("/DVDCategory/Index");
                }
            }
            else
            {
                ViewData["Error"] = "DVD Category Not found!";
                return Redirect("/DVDCategory/Index");
            }
        }
    }
}
