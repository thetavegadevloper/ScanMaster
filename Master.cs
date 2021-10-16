using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanMaster
{
    interface Master
    {
        bool CheckModelCodeExists(string ModelCode);
        bool CheckModelNameExists(string ModelName);
    }
}
