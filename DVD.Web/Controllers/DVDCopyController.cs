using DVD.Web.DbConnection;
using DVD.Web.EntityModel;
using DVD.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.Controllers
{
    public class DVDCopyController : Controller
    {
        DVDContext _dbconnection;
        public DVDCopyController(DVDContext dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public void DDL(DVDCopyModel model)
        {
            var items = _dbconnection.DVDTitle.ToList();
            var list = new List<SelectListItem>();
            var m = new SelectListItem();
            m.Value = "";
            m.Text = "Select DVD Title";
            list.Add(m);
            foreach (var item in items)
            {
                var data = new SelectListItem();
                data.Value = item.DVDNumber.ToString();
                data.Text = item.DVDNumber.ToString();
                if(model.DVDNumber == item.DVDNumber)
                {
                    data.Selected = true;
                }
                list.Add(data);
            }
            model.DVDTitleList = list;
        }
        public ActionResult Index()
        {
            var list = _dbconnection.DVDCopy.ToList();
            var lst = new List<DVDCopyModel>();
            foreach (var item in list)
            {
                var model = new DVDCopyModel();
                model.CopyNumber = item.CopyNumber;
                model.DVDNumber = item.DVDNumber;
                model.DatePurchased = item.DatePurchased;
                lst.Add(model); 
            }
            return View(lst);
        }
        public ActionResult AddDVDCopy()
        {
            var model = new DVDCopyModel();
            DDL(model);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDVDCopy(DVDCopyModel model)
        {
            if (ModelState.IsValid)
            {
                var entitymodel = new DVDCopy();
                entitymodel.DVDNumber = model.DVDNumber;
                entitymodel.DatePurchased = model.DatePurchased;
                var data = _dbconnection.Add<DVDCopy>(entitymodel);
                _dbconnection.SaveChanges();
                return Redirect("/DVDCopy/Index");
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                DDL(model);
                return View(model);
            }
        }
        public ActionResult UpdateDVDCopy()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.DVDCopy.Where(x => x.CopyNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    var model = new DVDCopyModel();
                    model.CopyNumber = data.CopyNumber;
                    model.DVDNumber = data.DVDNumber;
                    model.DatePurchased = data.DatePurchased;
                    DDL(model);
                    return View(model);
                }
                else
                {
                    return Redirect("/DVDCopy/Index");
                }
            }
            else
            {
                return Redirect("/DVDCopy/Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDVDCopy(DVDCopyModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _dbconnection.DVDCopy.Where(x => x.CopyNumber == model.CopyNumber).FirstOrDefault();
                if (item != null)
                {
                    item.DVDNumber = model.DVDNumber;
                    item.DatePurchased = model.DatePurchased;
                    _dbconnection.SaveChanges();
                    return Redirect("/DVDCopy/Index");
                }
                else
                {
                    ViewData["Error"] = "DVD Copy not found!";
                    return Redirect("/DVDCopy/UpdateDVDCopy?id=" + model.CopyNumber);
                }
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return Redirect("/DVDCopy/UpdateDVDCopy?id=" + model.CopyNumber);
            }
        }
        public ActionResult DeleteDVDCopy()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.DVDCopy.Where(x => x.CopyNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    _dbconnection.DVDCopy.Remove(data);
                    _dbconnection.SaveChanges();
                    ViewData["Error"] = "DVD Copy deleted successfully!";
                    return Redirect("/DVDCopy/Index");
                }
                else
                {
                    ViewData["Error"] = "DVD Copy Not found!";
                    return Redirect("/DVDCopy/Index");
                }
            }
            else
            {
                ViewData["Error"] = "DVD Copy Not found!";
                return Redirect("/DVDCopy/Index");
            }
        }
    }
}
