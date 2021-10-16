using ScanMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScanMaster.Interface;

namespace ScanMaster.Controllers
{
    public class LoginController : Controller
    {
       
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Login(UserMaster objUser)
        {
            if (ModelState.IsValid)
            {
                using (BarcodeScanEntities db = new BarcodeScanEntities())
                {
                    var obj = db.UserMasters.Where(a => a.UserName.Equals(objUser.UserName) && a.PWord.Equals(objUser.PWord)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["ID"] = obj.ID.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Dashboard","Admin");
                    }
                }
            }
            return View(objUser);
        }

        [NonAction]
        public void remove_Anonymous_Cookies()
        {
            try
            {

                if (Request.Cookies["WebTime"] != null)
                {
                    var option = new HttpCookie("WebTime");
                    option.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(option);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}