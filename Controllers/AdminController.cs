using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScanMaster.Controllers
{
    public class AdminController : Controller
    {
        BarcodeScanEntities db = new BarcodeScanEntities();
        [HttpGet]
        public ActionResult Dashboard()
        {
            var today = DateTime.Now.Date;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            foreach (var item in db.Reports.ToList())
            {
                int count = db.Reports.Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow).Select( m => m.TStamp).Distinct().Count();
                int count1 = db.Reports.Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow).Count();
                int count2 = db.Reports.Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow && x.Activestatus==true).Count();
                int count3 = db.Reports.Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow && x.Activestatus == false).Count();
                ViewBag.Count  =     count;
                ViewBag.Scancount =  count1;
                ViewBag.OKCount =    count2;
                ViewBag.NotOKCount = count3;
            }
            return View(db.Reports.Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow).ToList().OrderByDescending(s => s.ID));
        }
    }
}