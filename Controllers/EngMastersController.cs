using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScanMaster;
using ScanMaster.Models;
using PagedList.Mvc;
using PagedList;

namespace ScanMaster.Controllers
{
    public class EngMastersController : Controller
    {
        Master _master;
        private BarcodeScanEntities db = new BarcodeScanEntities();
        public EngMastersController()
        {
            _master = new EngineContext();
        
        }
        // GET: EngMasters
        public ActionResult Index(int? i )
        {
            return View(db.EngMasters.ToList().ToPagedList(i ?? 1, 10));
        }
        public JsonResult CheckModelCodeExists(string ModelCode)
        {
            try
            {
                var isModelCodeExists = false;

                if (ModelCode != null)
                {
                    isModelCodeExists = _master.CheckModelCodeExists(ModelCode);
                }

                if (isModelCodeExists)
                {
                    return Json(data: true);
                }
                else
                {
                    return Json(data: false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: EngMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngMaster engMaster = db.EngMasters.Find(id);
            if (engMaster == null)
            {
                return HttpNotFound();
            }
            return View(engMaster);
        }

        // GET: EngMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EngInsertView engviewmodel)
        {
            var engMaster = new EngMaster() { Barcode = engviewmodel.Barcode , ModelName = engviewmodel.ModelName,ModelCode= engviewmodel.ModelCode,CreatedDateTime = DateTime.Now };
          
            if (ModelState.IsValid)
            {
              
               
             
                db.EngMasters.Add(engMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(engMaster);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngMaster engMaster = db.EngMasters.Find(id);
            if (engMaster == null)
            {
                return HttpNotFound();
            }
            return View(engMaster);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EngMaster engMaster)
        {
            if (ModelState.IsValid)
            {
                EngMaster dbCompayObjct = new EngMaster { ID = engMaster.ID };
                db.EngMasters.Attach(dbCompayObjct);
                dbCompayObjct.Barcode = engMaster.Barcode;
                dbCompayObjct.ModelName = engMaster.ModelName;
                dbCompayObjct.ModelCode = engMaster.ModelCode;
                dbCompayObjct.UpdatesDateTime = DateTime.Now;
                dbCompayObjct.UpdateNo = engMaster.UpdateNo;
                dbCompayObjct.Activestatus = engMaster.Activestatus;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(engMaster);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngMaster engMaster = db.EngMasters.Find(id);
            if (engMaster == null)
            {
                return HttpNotFound();
            }
            return View(engMaster);
        }

        // POST: EngMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EngMaster engMaster = db.EngMasters.Find(id);
            db.EngMasters.Remove(engMaster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
