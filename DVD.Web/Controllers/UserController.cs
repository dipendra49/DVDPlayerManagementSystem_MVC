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
    public class UserController : Controller
    {
        DVDContext _dbconnection;
        public UserController(DVDContext dbconnection)
        {
            _dbconnection = dbconnection;
        }
        public void DropDownList(UserModel model)
        {

            List<SelectListItem> UsrTypeList = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Select User Type",Value = ""},
                new SelectListItem(){Text = "Admin",Value = "Admin"},
                new SelectListItem(){Text = "User",Value = "User"},
                new SelectListItem(){Text = "Manager",Value = "Manager"},
            };
            if (!string.IsNullOrEmpty(model.UserType))
            {
                foreach (var item in UsrTypeList)
                {
                    if (model.UserType.ToLower() == item.Value.ToLower())
                    {
                        item.Selected = true;
                    }
                }
            }
            model.UserTypeList = UsrTypeList;
        }
        public ActionResult Index()
        {
            var list = _dbconnection.User.ToList();
            var lst = new List<UserModel>();
            foreach (var item in list)
            {
                var model = new UserModel();
                model.UserName = item.UserName;
                model.UserNumber = item.UserNumber;
                model.UserType = item.UserType;
                lst.Add(model);
            }
            return View(lst);
        }
        public ActionResult AddUser()
        {
            var model = new UserModel();
            DropDownList(model);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var item = _dbconnection.User.Where(x => x.UserName == model.UserName).FirstOrDefault();
                if (item == null)
                {
                    var entitymodel = new User();
                    entitymodel.UserName = model.UserName;
                    entitymodel.UserType = model.UserType;
                    entitymodel.UserPassword = model.UserPassword;
                    var data = _dbconnection.Add<User>(entitymodel);
                    _dbconnection.SaveChanges();
                    return Redirect("/User/Index");
                }
                else
                {
                    DropDownList(model);
                    ViewData["Error"] = "User Name already exists!";
                    return View(model);
                }
            }
            else
            {
                DropDownList(model);
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return View(model);
            }
        }
        public ActionResult UpdateUser()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.User.Where(x => x.UserNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    var model = new UserModel();
                    model.UserNumber = data.UserNumber;
                    model.UserName = data.UserName;
                    model.UserType = data.UserType;
                    DropDownList(model);
                    return View(model);
                }
                else
                {
                    return Redirect("/User/Index");
                }
            }
            else
            {
                return Redirect("/User/Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(UserModel model)
        {
            ModelState.Remove("UserPassword");
            if (ModelState.IsValid)
            {
                var item = _dbconnection.User.Where(x => x.UserNumber == model.UserNumber).FirstOrDefault();
                if (item != null)
                {
                    var data = _dbconnection.User.Where(x => x.UserNumber != model.UserNumber).ToList();
                    foreach (var items in data)
                    {
                        if (items.UserName == model.UserName)
                        {
                            ViewData["Error"] = "User Name already exists!";
                            return Redirect("/User/UpdateUser?id=" + model.UserNumber);
                        }
                    }
                    item.UserName = model.UserName;
                    item.UserType = model.UserType;
                    _dbconnection.SaveChanges();
                    return Redirect("/User/Index");
                }
                else
                {
                    ViewData["Error"] = "User not found!";
                    return Redirect("/User/UpdateUser?id=" + model.UserNumber);
                }
            }
            else
            {
                DropDownList(model);
                var errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                ViewData["Error"] = errors;
                return Redirect("/User/UpdateUser?id=" + model.UserNumber);
            }
        }
        public ActionResult DeleteUser()
        {
            if (Request.Query.ContainsKey("id"))
            {
                var id = Request.Query["id"].ToString();
                var data = _dbconnection.User.Where(x => x.UserNumber == Convert.ToInt32(id)).FirstOrDefault();
                if (data != null)
                {
                    _dbconnection.User.Remove(data);
                    _dbconnection.SaveChanges();
                    ViewData["Error"] = "User deleted successfully!";
                    return Redirect("/User/Index");
                }
                else
                {
                    ViewData["Error"] = "User Not found!";
                    return Redirect("/User/Index");
                }
            }
            else
            {
                ViewData["Error"] = "User Not found!";
                return Redirect("/User/Index");
            }
        }
    }
}
