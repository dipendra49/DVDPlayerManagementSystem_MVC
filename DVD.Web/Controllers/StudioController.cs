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
    public class StudioController : Controller
    {
        DVDContext _dbconnection;
        public StudioController(DVDContext dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public ActionResult Index()
        {
            var list = _dbconnection.Studio.ToList();
            var lst = new List<StudioModel>();
            foreach (var item in list)
            {
                var model = new StudioModel();
                model.StudioNumber = item.StudioNumber;
                model.StudioName = item.StudioName;
                lst.Add(model);
            }
            return View(lst);
        }
        public ActionResult AddStudio()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudio(StudioModel model)
        {
            if (ModelState.IsValid)
            {
                var entitymodel = new Studio();
                entitymodel.StudioName = model.StudioName;
                var data = _dbconnection.Add<Studio>(entitymodel);
                _dbconnection.SaveChanges();
                return Redirect("/Studio/Index");
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return View(model);
            }
        }
        public ActionResult UpdateStudio()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.Studio.Where(x => x.StudioNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    var model = new StudioModel();
                    model.StudioNumber = data.StudioNumber;
                    model.StudioName = data.StudioName;
                    return View(model);
                }
                else
                {
                    return Redirect("/Studio/Index");
                }
            }
            else
            {
                return Redirect("/Studio/Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStudio(StudioModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _dbconnection.Studio.Where(x => x.StudioNumber == model.StudioNumber).FirstOrDefault();
                if (item != null)
                {
                    item.StudioName = model.StudioName;
                    _dbconnection.SaveChanges();
                    return Redirect("/Studio/Index");
                }
                else
                {
                    ViewData["Error"] = "Studio not found!";
                    return Redirect("/Studio/UpdateStudio?id=" + model.StudioNumber);
                }
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return Redirect("/Studio/UpdateStudio?id=" + model.StudioNumber);
            }
        }
        public ActionResult DeleteStudio()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.Studio.Where(x => x.StudioNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    _dbconnection.Studio.Remove(data);
                    _dbconnection.SaveChanges();
                    ViewData["Error"] = "Studio deleted successfully!";
                    return Redirect("/Studio/Index");
                }
                else
                {
                    ViewData["Error"] = "Studio Not found!";
                    return Redirect("/Studio/Index");
                }
            }
            else
            {
                ViewData["Error"] = "Studio Not found!";
                return Redirect("/Studio/Index");
            }
        }
    }
}
