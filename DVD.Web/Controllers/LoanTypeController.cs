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
    public class LoanTypeController : Controller
    {
        DVDContext _dbconnection;
        public LoanTypeController(DVDContext dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public ActionResult Index()
        {
            var list = _dbconnection.LoanType.ToList();
            var lst = new List<LoanTypeModel>();
            foreach (var item in list)
            {
                var model = new LoanTypeModel();
                model.LoanTypeNumber = item.LoanTypeNumber;
                model.LoanType = item.LoanType;
                model.LoanDuration = item.LoanDuration;
                lst.Add(model);
            }
            return View(lst);
        }
        public ActionResult AddLoanType()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLoanType(LoanTypeModel model)
        {
            if (ModelState.IsValid)
            {
                var entitymodel = new LoanTypes();
                entitymodel.LoanType = model.LoanType;
                entitymodel.LoanDuration = model.LoanDuration;
                var data = _dbconnection.Add<LoanTypes>(entitymodel);
                _dbconnection.SaveChanges();
                return Redirect("/LoanType/Index");
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return View(model);
            }
        }
        public ActionResult UpdateLoanType()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.LoanType.Where(x => x.LoanTypeNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    var model = new LoanTypeModel();
                    model.LoanTypeNumber = data.LoanTypeNumber;
                    model.LoanType = data.LoanType;
                    model.LoanDuration = data.LoanDuration;
                    return View(model);
                }
                else
                {
                    return Redirect("/LoanType/Index");
                }
            }
            else
            {
                return Redirect("/LoanType/Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateLoanType(LoanTypeModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _dbconnection.LoanType.Where(x => x.LoanTypeNumber == model.LoanTypeNumber).FirstOrDefault();
                if (item != null)
                {
                    item.LoanType = model.LoanType;
                    item.LoanDuration = model.LoanDuration;
                    _dbconnection.SaveChanges();
                    return Redirect("/LoanType/Index");
                }
                else
                {
                    ViewData["Error"] = "Loan Type not found!";
                    return Redirect("/LoanType/UpdateLoanType?id=" + model.LoanTypeNumber);
                }
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return Redirect("/LoanType/UpdateLoanType?id=" + model.LoanTypeNumber);
            }
        }
        public ActionResult DeleteLoanType()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.LoanType.Where(x => x.LoanTypeNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    _dbconnection.LoanType.Remove(data);
                    _dbconnection.SaveChanges();
                    ViewData["Error"] = "Loan Type deleted successfully!";
                    return Redirect("/LoanType/Index");
                }
                else
                {
                    ViewData["Error"] = "Loan Type Not found!";
                    return Redirect("/LoanType/Index");
                }
            }
            else
            {
                ViewData["Error"] = "Loan Type Not found!";
                return Redirect("/LoanType/Index");
            }
        }
    }
}
