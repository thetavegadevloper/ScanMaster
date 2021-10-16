using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScanMaster.Controllers
{
    public class EngineContext : Master
    {
        public bool CheckModelCodeExists(string ModelCode)
        {
            try
            {
                using (var _context = new BarcodeScanEntities())
                {
                    var result = (from Model in _context.EngMasters
                                  where Model.ModelCode == ModelCode
                                  select Model).Count();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckModelNameExists(string ModelName)
        {
            throw new NotImplementedException();
        }
    }
}