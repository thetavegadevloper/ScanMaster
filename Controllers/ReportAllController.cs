using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace ScanMaster.Controllers
{
    public class ReportAllController : Controller
    {
      //  public int i;
        private BarcodeScanEntities db = new BarcodeScanEntities();


        // GET: ReportAll

        public ActionResult Report( string search)
        {
            // ModelCode = Request.Form["ModelCode"].ToString();
            return View(db.Reports.Where(m=> m.ModelCode.StartsWith(search) || search == null).ToList().OrderByDescending(s => s.ID));
        }

        public ActionResult Report2()
        {
            var today = DateTime.Now.Date;
            return View(db.Reports.ToList().OrderByDescending(s => s.ID));
        }
 
        public ActionResult ScannedCode()
        {
            var today = DateTime.Now.Date;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            return PartialView(db.Reports.ToList().Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow));
        }

        public ActionResult partname()
        {
            var today = DateTime.Now.Date;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            return PartialView(db.Reports.ToList().Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow));
        }
        public ActionResult okcountv()
        {
            var today = DateTime.Now.Date;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            return PartialView(db.Reports.ToList().Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow && x.Activestatus == true));
        }
        public ActionResult Notokcountv()
        {
            var today = DateTime.Now.Date;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            return PartialView(db.Reports.ToList().Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow && x.Activestatus == false));
        }
       



        [HttpPost]
        public ActionResult Report2(DateTime search, DateTime search2)
        {
                // List<Report> list = db.Reports.ToList();
            if (search != null && search2 != null)
            {
                 return View(db.Reports.Where(m => m.CreatedDate >= search && m.CreatedDate <= search2).ToList());
               // var result = db.getreportssp(search, search2).ToList();
               //  return View(db.getreportssp(search, search2).ToList());

            }
            return Json("Not Valid Datetime");
        }

        [HttpPost]
        public ActionResult ScannedCode(DateTime search)
        {
            var today = search;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);

            return PartialView(db.Reports.ToList().Where(x => x.CreatedDate >= search && x.CreatedDate <= tomorrow));
        }

        [HttpPost]
        public ActionResult partname(DateTime search)
        {
            var today = search;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            return PartialView(db.Reports.ToList().Where(x => x.CreatedDate >= search && x.CreatedDate < tomorrow));
        }

        [HttpPost]
        public ActionResult okcountv(DateTime search)
        {
            var today = search;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            return PartialView(db.Reports.ToList().Where(x => x.CreatedDate >= search && x.CreatedDate < tomorrow && x.Activestatus == true));
        }
        [HttpPost]
        public ActionResult Notokcountv(DateTime search)
        {
            var today = search;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            return PartialView(db.Reports.ToList().Where(x => x.CreatedDate >= search && x.CreatedDate < tomorrow && x.Activestatus == false));
        }

        public JsonResult Notokcountvs(DateTime search)
        {
            var today = search;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            int count3 = db.Reports.Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow && x.Activestatus == false).Count();
            return new JsonResult { Data = count3, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult okcountvs(DateTime search)
        {
            var today = search;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            int count3 = db.Reports.Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow && x.Activestatus == true).Count();
            return new JsonResult { Data = count3, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult part(DateTime search)
        {
            var today = search;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            int count3 = db.Reports.Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow).Count();
            return new JsonResult { Data = count3, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult scanned(DateTime search)
        {
            var today = search;
            today = today.AddSeconds(-today.Second);
            var tomorrow = today.AddDays(1);
            DateTime dt = DateTime.Now;
            dt = dt.AddSeconds(-dt.Second);
            int count3 = db.Reports.Where(x => x.CreatedDate >= today && x.CreatedDate < tomorrow).Select(m => m.TStamp).Distinct().Count();
            return new JsonResult { Data = count3, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}