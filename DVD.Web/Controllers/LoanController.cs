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
    public class LoanController : Controller
    {
        DVDContext _dbconnection;
        public LoanController(DVDContext dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public void DDL(LoanModel model)
        {
            var loantypeitems = _dbconnection.LoanType.ToList();
            var loantypelist = new List<SelectListItem>();
            var loantypemodel = new SelectListItem();
            loantypemodel.Value = "";
            loantypemodel.Text = "Select Loan Type";
            loantypelist.Add(loantypemodel);
            foreach (var item in loantypeitems)
            {
                var data = new SelectListItem();
                data.Value = item.LoanTypeNumber.ToString();
                data.Text = item.LoanType.ToString();
                if (model.LoanTypeNumber == item.LoanTypeNumber)
                {
                    data.Selected = true;
                }
                loantypelist.Add(data);
            }
            model.LoanTypeList = loantypelist;

            var dvdcopyitems = _dbconnection.DVDCopy.ToList();
            var dvdcopylist = new List<SelectListItem>();
            var dvdcopymodel = new SelectListItem();
            dvdcopymodel.Value = "";
            dvdcopymodel.Text = "Select DVD Copy";
            dvdcopylist.Add(dvdcopymodel);
            foreach (var item in dvdcopyitems)
            {
                var data = new SelectListItem();
                data.Value = item.CopyNumber.ToString();
                data.Text = item.CopyNumber.ToString();
                if (model.CopyNumber == item.CopyNumber)
                {
                    data.Selected = true;
                }
                dvdcopylist.Add(data);
            }
            model.DVDCopyList = dvdcopylist;

            var memberitems = _dbconnection.Member.ToList();
            var memberlist = new List<SelectListItem>();
            var membermodel = new SelectListItem();
            membermodel.Value = "";
            membermodel.Text = "Select Member";
            memberlist.Add(membermodel);
            foreach (var item in memberitems)
            {
                var data = new SelectListItem();
                data.Value = item.MemberNumber.ToString();
                data.Text = string.Concat(item.MemberFirstName," ", item.MemberLastName).ToString();
                if (model.MemberNumber == item.MemberNumber)
                {
                    data.Selected = true;
                }
                memberlist.Add(data);
            }
            model.MemberList = memberlist;
        }
        public ActionResult Index()
        {
            var list = _dbconnection.Loan.ToList();
            var lst = new List<LoanModel>();
            foreach (var item in list)
            {
                var model = new LoanModel();
                model.LoanNumber = item.LoanNumber;
                model.LoanType = _dbconnection.LoanType.Where(x => x.LoanTypeNumber == item.LoanTypeNumber).Select(x => x.LoanType).FirstOrDefault();
                model.CopyNumber = _dbconnection.DVDCopy.Where(x => x.CopyNumber == item.CopyNumber).Select(x => x.CopyNumber).FirstOrDefault();
                model.Member = string.Concat(_dbconnection.Member.Where(x => x.MemberNumber == item.MemberNumber).Select(x => x.MemberFirstName).FirstOrDefault()," ", _dbconnection.Member.Where(x => x.MemberNumber == item.MemberNumber).Select(x => x.MemberFirstName).FirstOrDefault());
                model.DateOut = item.DateOut;
                model.DateDue = item.DateDue;
                model.DateReturned = item.DateReturned;
                lst.Add(model);
            }
            return View(lst);
        }
        public ActionResult AddLoan()
        {
            var model = new LoanModel();
            DDL(model);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLoan(LoanModel model)
        {
            if (ModelState.IsValid)
            {
                var entitymodel = new Loan();
                entitymodel.LoanTypeNumber = model.LoanTypeNumber;
                entitymodel.CopyNumber = model.CopyNumber;
                entitymodel.MemberNumber = model.MemberNumber;
                entitymodel.DateOut = model.DateOut;
                entitymodel.DateDue = model.DateDue;
                entitymodel.DateReturned = model.DateReturned;
                var data = _dbconnection.Add<Loan>(entitymodel);
                _dbconnection.SaveChanges();
                return Redirect("/Loan/Index");
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                DDL(model);
                return View(model);
            }
        }
        public ActionResult UpdateLoan()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.Loan.Where(x => x.LoanNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    var model = new LoanModel();
                    model.LoanNumber = data.LoanNumber;
                    model.LoanTypeNumber = data.LoanTypeNumber;
                    model.CopyNumber = data.CopyNumber;
                    model.MemberNumber = data.MemberNumber;
                    model.DateOut = data.DateOut;
                    model.DateDue = data.DateDue;
                    model.DateReturned = data.DateReturned;
                    DDL(model);
                    return View(model);
                }
                else
                {
                    return Redirect("/Loan/Index");
                }
            }
            else
            {
                return Redirect("/Loan/Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateLoan(LoanModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _dbconnection.Loan.Where(x => x.LoanNumber == model.LoanNumber).FirstOrDefault();
                if (item != null)
                {
                    item.LoanTypeNumber = model.LoanTypeNumber;
                    item.CopyNumber = model.CopyNumber;
                    item.MemberNumber = model.MemberNumber;
                    item.DateOut = model.DateOut;
                    item.DateDue = model.DateDue;
                    item.DateReturned = model.DateReturned;
                    _dbconnection.SaveChanges();
                    return Redirect("/Loan/Index");
                }
                else
                {
                    ViewData["Error"] = "Loan not found!";
                    return Redirect("/Loan/UpdateLoan?id=" + model.LoanNumber);
                }
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return Redirect("/Loan/UpdateLoan?id=" + model.LoanNumber);
            }
        }
        public ActionResult DeleteLoan()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.Loan.Where(x => x.LoanNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    _dbconnection.Loan.Remove(data);
                    _dbconnection.SaveChanges();
                    ViewData["Error"] = "Loan deleted successfully!";
                    return Redirect("/Loan/Index");
                }
                else
                {
                    ViewData["Error"] = "Loan Not found!";
                    return Redirect("/Loan/Index");
                }
            }
            else
            {
                ViewData["Error"] = "Loan Not found!";
                return Redirect("/Loan/Index");
            }
        }
    }
}
