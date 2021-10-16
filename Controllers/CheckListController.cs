using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ScanMaster.Controllers
{
    public class CheckListController : ApiController
    {

        private BarcodeScanEntities db = new BarcodeScanEntities();

        // GET: api/Checklist_Master
        public IQueryable<ModelMaster2> GetChecklist_Master()
        {
            return db.ModelMaster2;
        }

        // GET: api/Checklist_Master/5
        [ResponseType(typeof(ModelMaster2))]
        public IHttpActionResult GetChecklist_Master(string Bcode)
        {
            using (var ctx = new BarcodeScanEntities())
            {
                var CheckList = ctx.ModelMaster2.Where(s => s.Barcode == Bcode).ToList();
                if (CheckList == null)
                {
                    return NotFound();
                }

                return Ok(CheckList);
            }
        }
    }
}
