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
    public class ProducerController : Controller
    {
        DVDContext _dbconnection;
        public ProducerController(DVDContext dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public ActionResult Index()
        {
            var list = _dbconnection.Producer.ToList();
            var lst = new List<ProducerModel>();
            foreach (var item in list)
            {
                var model = new ProducerModel();
                model.ProducerNumber = item.ProducerNumber;
                model.ProducerName = item.ProducerName;
                lst.Add(model);
            }
            return View(lst);
        }
        public ActionResult AddProducer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProducer(ProducerModel model)
        {
            if (ModelState.IsValid)
            {
                var entitymodel = new Producer();
                entitymodel.ProducerName = model.ProducerName;
                var data = _dbconnection.Add<Producer>(entitymodel);
                _dbconnection.SaveChanges();
                return Redirect("/Producer/Index");
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return View(model);
            }
        }
        public ActionResult UpdateProducer()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.Producer.Where(x => x.ProducerNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    var model = new ProducerModel();
                    model.ProducerNumber = data.ProducerNumber;
                    model.ProducerName = data.ProducerName;
                    return View(model);
                }
                else
                {
                    return Redirect("/Producer/Index");
                }
            }
            else
            {
                return Redirect("/Producer/Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProducer(ProducerModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _dbconnection.Producer.Where(x => x.ProducerNumber == model.ProducerNumber).FirstOrDefault();
                if (item != null)
                {
                    item.ProducerName = model.ProducerName;
                    _dbconnection.SaveChanges();
                    return Redirect("/Producer/Index");
                }
                else
                {
                    ViewData["Error"] = "Producer not found!";
                    return Redirect("/Producer/UpdateProducer?id=" + model.ProducerNumber);
                }
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return Redirect("/Producer/UpdateProducer?id=" + model.ProducerNumber);
            }
        }
        public ActionResult DeleteProducer()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.Producer.Where(x => x.ProducerNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    _dbconnection.Producer.Remove(data);
                    _dbconnection.SaveChanges();
                    ViewData["Error"] = "Producer deleted successfully!";
                    return Redirect("/Producer/Index");
                }
                else
                {
                    ViewData["Error"] = "Producer Not found!";
                    return Redirect("/Producer/Index");
                }
            }
            else
            {
                ViewData["Error"] = "Producer Not found!";
                return Redirect("/Producer/Index");
            }
        }
    }
}
