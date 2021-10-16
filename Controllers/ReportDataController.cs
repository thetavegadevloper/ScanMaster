using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ScanMaster.Controllers
{
    public class ReportDataController : ApiController
    {
       
        [HttpPost]
        public IHttpActionResult PostChecklist2(List<Report> Listt)
        {
            using (BarcodeScanEntities entities = new BarcodeScanEntities())
            {
                var today = DateTime.Now;               
                if (Listt == null)
                {
                    Listt = new List<Report>();
                }

                foreach (Report Listts in Listt)
                {
                    Listts.CreatedDate = DateTime.Now;
                    Listts.TStamp = today.ToString();
                    entities.Reports.Add(Listts);
                }
                int insertedRecords = entities.SaveChanges();
                return Json(insertedRecords);
            }
        }
    }
}
