using ScanMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Net.Http;
using System.IO;

namespace ScanMaster.Controllers
{
    public class ModelMasterController : Controller
    {
        private BarcodeScanEntities db = new BarcodeScanEntities();
        public ActionResult AddModel2()
        {
          
            return View();
        }
        public ActionResult AddModel()
        {
            //var namelist = (from EngMaster in db.EngMasters
            //                    select new SelectListItem()
            //                    {
            //                        Text = EngMaster.ModelName,
            //                        Value = EngMaster.ID.ToString(),
            //                    }).ToList();

          
            //var Barcodelist = (from EngMaster in db.EngMasters
            //                    select new SelectListItem()
            //                    {
            //                        Text = EngMaster.Barcode,
            //                        Value = EngMaster.ID.ToString(),
            //                    }).ToList();

          
            //var ModelCodelist = (from EngMaster in db.EngMasters
            //                   select new SelectListItem()
            //                   {
            //                       Text = EngMaster.ModelCode,
            //                       Value = EngMaster.ID.ToString(),
            //                   }).ToList();

          
            //ModelMaster2 md = new ModelMaster2();
            //md.ModelNamelist = namelist;
            //md.Barcodelist = Barcodelist;
            //md.Modelcodelist = ModelCodelist;

            return View();
          
        }
        public ActionResult Details(string search, int? i )
        {

            return View(db.ModelMaster2.Where(m => m.ModelName.StartsWith(search) || search == null).ToList().OrderByDescending(s => s.ID).ToPagedList(i ?? 1, 10));
        }

        public ActionResult EditModel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelMaster2 Master = db.ModelMaster2.Find(id);
            if (Master == null)
            {
                return HttpNotFound();
            }
            return View(Master);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditModel(ModelMaster2 Master)
        {
            if (ModelState.IsValid)
            {
                ModelMaster2 dbCompayObjct = new ModelMaster2 { ID = Master.ID };
                db.ModelMaster2.Attach(dbCompayObjct);
                dbCompayObjct.ModelName = Master.ModelName;
                dbCompayObjct.ModelCode = Master.ModelCode;
                dbCompayObjct.PartType = Master.PartType;
                dbCompayObjct.PartName = Master.PartName;
                dbCompayObjct.UpdatedDate = DateTime.Now;
                dbCompayObjct.Activestatus = Master.Activestatus;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(Master);
        }
        public ActionResult DeleteModel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelMaster2 engMaster = db.ModelMaster2.Find(id);
            if (engMaster == null)
            {
                return HttpNotFound();
            }
            return View(engMaster);
        }

        // POST: EngMasters/Delete/5
        [HttpPost, ActionName("DeleteModel")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelMaster2 engMaster = db.ModelMaster2.Find(id);
            db.ModelMaster2.Remove(engMaster);
            db.SaveChanges();
            return RedirectToAction("Details");
        }
        public JsonResult GetModelName()
        {
            List<EngMaster> Names = new List<EngMaster>();
            using (BarcodeScanEntities dc = new BarcodeScanEntities())
            {
                Names = dc.EngMasters.OrderBy(a => a.ModelName).ToList();
            }
            return new JsonResult { Data = Names, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetModelCode()
        {
            List<EngMaster> Codes = new List<EngMaster>();
            using (BarcodeScanEntities dc = new BarcodeScanEntities())
            {
                Codes = dc.EngMasters.OrderBy(a => a.ModelCode).ToList();
            }
            return new JsonResult { Data = Codes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetBarCode()
        {
            List<EngMaster> Codes = new List<EngMaster>();
            using (BarcodeScanEntities dc = new BarcodeScanEntities())
            {
                Codes = dc.EngMasters.OrderBy(a => a.Barcode).ToList();
            }
            return new JsonResult { Data = Codes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetModelNamedetails(string modelname)
        {
            List<EngMaster> allUser = new List<EngMaster>();

           // prefix = "Platina 100 ES BS6";
            // Here "MyDatabaseEntities " is dbContext, which is created at time of model creation.

            using (BarcodeScanEntities dc = new BarcodeScanEntities())
            {
                allUser = dc.EngMasters.Where(a => a.ModelName== modelname).ToList();
            }

            return new JsonResult { Data = allUser, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetCategoryList()
        {
            List<Category> cate = new List<Category>();
            using (BarcodeScanEntities dc = new BarcodeScanEntities())
            {
                cate = dc.Categories.OrderBy(a => a.TypeName).ToList();
            }
            return new JsonResult { Data = cate, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        
        //public ActionResult Createmodelrecord(ModelMaster2 eventmodel)
        //{
        //    BarcodeScanEntities db = new BarcodeScanEntities();
        //    if (eventmodel.ModelName != null && eventmodel.Imagefile != null)
        //    {
        //        string fileName = Path.GetFileNameWithoutExtension(eventmodel.Imagefile.FileName);
        //        string extension = Path.GetExtension(eventmodel.Imagefile.FileName);
        //        fileName = fileName  + extension;
        //        eventmodel.Imagefile.SaveAs(Path.Combine(Server.MapPath("~/Content/Images"), fileName));
        //        eventmodel.ImagePath = "~/Content/Images"+ fileName;
        //        eventmodel.CreatedDate = DateTime.Now;
        //        eventmodel.Activestatus = false;
        //        db.ModelMaster2.Add(eventmodel);
        //        db.SaveChanges();
        //    }
        //    var result = db.SaveChanges();
        //    //   ViewBag.result = "Record Inserted Successfully!";
        //    TempData["Referrer"] = "SaveRegister";
        //    return View();
        //}

        [HttpPost]
        public JsonResult InsertModelData(ModelMaster2 ModelData)

        {
            BarcodeScanEntities entities = new BarcodeScanEntities();

                if (Request.Files.Count >= 0)
                {
                   
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                    HttpPostedFileBase postedFile = Request.Files[i];
                    string fileName = Path.GetFileName(postedFile.FileName);

                    string path = Server.MapPath("~/Content/Images/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    postedFile.SaveAs(path + fileName);
                        ModelData.ImagePath = fileName;
                    }
                    ModelData.ModelName = Request.Form["ModelName"];
                    ModelData.ModelCode = Request.Form["ModelCode"];
                    ModelData.Barcode = Request.Form["Barcode"];
                    ModelData.PartName = Request.Form["PartName"];
                    ModelData.PartDescription = Request.Form["PartDescription"];
                    ModelData.PartNo = Request.Form["PartNo"];
                    ModelData.PartType = Request.Form["PartType"];
                    ModelData.CreatedDate = DateTime.Now;
                    ModelData.Activestatus = false;
                    entities.ModelMaster2.Add(ModelData);

                }
                int insertedRecords = entities.SaveChanges();
                return Json(insertedRecords);
            
        }
    }
}