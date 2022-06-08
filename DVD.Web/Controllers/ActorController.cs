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
    public class ActorController : Controller
    {
        DVDContext _dbconnection;
        public ActorController(DVDContext dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public ActionResult Index()
        {
            var list = _dbconnection.Actor.ToList();
            var lst = new List<ActorModel>();
            foreach (var item in list)
            {
                var model = new ActorModel();
                model.ActorNumber = item.ActorNumber;
                model.ActorFirstName = item.ActorFirstName;
                model.ActorSurname = item.ActorSurname;
                lst.Add(model);
            }
            return View(lst);
        }
        public ActionResult AddActor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddActor(ActorModel model)
        {
            if (ModelState.IsValid)
            {
                var entitymodel = new Actor();
                entitymodel.ActorFirstName = model.ActorFirstName;
                entitymodel.ActorSurname = model.ActorSurname;
                var data = _dbconnection.Add<Actor>(entitymodel);
                _dbconnection.SaveChanges();
                return Redirect("/Actor/Index");
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return View(model);
            }
        }
        public ActionResult UpdateActor()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.Actor.Where(x => x.ActorNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    var model = new ActorModel();
                    model.ActorNumber = data.ActorNumber;
                    model.ActorFirstName = data.ActorFirstName;
                    model.ActorSurname = data.ActorSurname;
                    return View(model);
                }
                else
                {
                    return Redirect("/Actor/Index");
                }
            }
            else
            {
                return Redirect("/Actor/Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateActor(ActorModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _dbconnection.Actor.Where(x => x.ActorNumber == model.ActorNumber).FirstOrDefault();
                if (item != null)
                {
                    item.ActorFirstName = model.ActorFirstName;
                    item.ActorSurname = model.ActorSurname;
                    _dbconnection.SaveChanges();
                    return Redirect("/Actor/Index");
                }
                else
                {
                    ViewData["Error"] = "Actor not found!";
                    return Redirect("/Actor/UpdateActor?id=" + model.ActorNumber);
                }
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return Redirect("/Actor/UpdateActor?id=" + model.ActorNumber);
            }
        }
        public ActionResult DeleteActor()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.Actor.Where(x => x.ActorNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    _dbconnection.Actor.Remove(data);
                    _dbconnection.SaveChanges();
                    ViewData["Error"] = "Actor deleted successfully!";
                    return Redirect("/Actor/Index");
                }
                else
                {
                    ViewData["Error"] = "Actor Not found!";
                    return Redirect("/Actor/Index");
                }
            }
            else
            {
                ViewData["Error"] = "Actor Not found!";
                return Redirect("/Actor/Index");
            }
        }
    }
}
