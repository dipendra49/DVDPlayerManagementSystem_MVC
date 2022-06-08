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
    public class MemberController : Controller
    {
        DVDContext _dbconnection;
        public MemberController(DVDContext dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public void DDL(MemberModel model)
        {
            var items = _dbconnection.MembershipCategory.ToList();
            var list = new List<SelectListItem>();
            var m = new SelectListItem();
            m.Value = "";
            m.Text = "Select Membership Category";
            list.Add(m);
            foreach (var item in items)
            {
                var data = new SelectListItem();
                data.Value = item.MembershipCategoryNumber.ToString();
                data.Text = item.MembershipCategoryDescription.ToString();
                if (model.MembershipCategoryNumber == item.MembershipCategoryNumber)
                {
                    data.Selected = true;
                }
                list.Add(data);
            }
            model.MembershipCategoryList = list;
        }
        public ActionResult Index()
        {
            var list = _dbconnection.Member.ToList();
            var lst = new List<MemberModel>();
            foreach (var item in list)
            {
                var model = new MemberModel();
                model.MemberNumber = item.MemberNumber;
                model.MembershipCategoryDescription = _dbconnection.MembershipCategory.Where(x => x.MembershipCategoryNumber == item.MembershipCategoryNumber).Select(x => x.MembershipCategoryDescription).FirstOrDefault();
                model.MemberLastName = item.MemberLastName;
                model.MemberFirstName = item.MemberFirstName;
                model.MemberAddress = item.MemberAddress;
                model.MemberDOB = item.MemberDOB;
                lst.Add(model);
            }
            return View(lst);
        }
        public ActionResult AddMember()
        {
            var model = new MemberModel();
            DDL(model);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMember(MemberModel model)
        {
            if (ModelState.IsValid)
            {
                var entitymodel = new Member();
                entitymodel.MembershipCategoryNumber = model.MembershipCategoryNumber;
                entitymodel.MemberLastName = model.MemberLastName;
                entitymodel.MemberFirstName = model.MemberFirstName;
                entitymodel.MemberAddress = model.MemberAddress;
                entitymodel.MemberDOB = model.MemberDOB;
                var data = _dbconnection.Add<Member>(entitymodel);
                _dbconnection.SaveChanges();
                return Redirect("/Member/Index");
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                DDL(model);
                return View(model);
            }
        }
        public ActionResult UpdateMember()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.Member.Where(x => x.MemberNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    var model = new MemberModel();
                    model.MemberNumber = data.MemberNumber;
                    model.MembershipCategoryNumber = data.MembershipCategoryNumber;
                    model.MemberLastName = data.MemberLastName;
                    model.MemberFirstName = data.MemberFirstName;
                    model.MemberAddress = data.MemberAddress;
                    model.MemberDOB = data.MemberDOB;
                    DDL(model);
                    return View(model);
                }
                else
                {
                    return Redirect("/Member/Index");
                }
            }
            else
            {
                return Redirect("/Member/Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMember(MemberModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _dbconnection.Member.Where(x => x.MemberNumber == model.MemberNumber).FirstOrDefault();
                if (item != null)
                {
                    item.MembershipCategoryNumber = model.MembershipCategoryNumber;
                    item.MemberLastName = model.MemberLastName;
                    item.MemberFirstName = model.MemberFirstName;
                    item.MemberAddress = model.MemberAddress;
                    item.MemberDOB = model.MemberDOB;
                    _dbconnection.SaveChanges();
                    return Redirect("/Member/Index");
                }
                else
                {
                    ViewData["Error"] = "Member not found!";
                    return Redirect("/Member/UpdateMember?id=" + model.MemberNumber);
                }
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return Redirect("/Member/UpdateMember?id=" + model.MemberNumber);
            }
        }
        public ActionResult DeleteMember()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.Member.Where(x => x.MemberNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    _dbconnection.Member.Remove(data);
                    _dbconnection.SaveChanges();
                    ViewData["Error"] = "Member deleted successfully!";
                    return Redirect("/Member/Index");
                }
                else
                {
                    ViewData["Error"] = "Member Not found!";
                    return Redirect("/Member/Index");
                }
            }
            else
            {
                ViewData["Error"] = "Member Not found!";
                return Redirect("/Member/Index");
            }
        }
    }
}
