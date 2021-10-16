using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ScanMaster.Controllers
{
    public class ModelDataController : ApiController
    {

        private BarcodeScanEntities db = new BarcodeScanEntities();

        // GET: api/Checklist_Master
        public IQueryable<EngMaster> GetChecklist_Master()
        {
            return db.EngMasters;
        }

        // GET: api/Checklist_Master/5
        [ResponseType(typeof(ModelMaster2))]
        public IHttpActionResult GetChecklist_Master(string Bcode)
        {
            using (var ctx = new BarcodeScanEntities())
            {
                var EngData = ctx.EngMasters.Where(s => s.Barcode == Bcode).ToList();
                if (EngData == null)
                {
                    return NotFound();
                }

                return Ok(EngData);
            }
        }
    }
}
