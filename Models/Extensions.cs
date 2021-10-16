using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScanMaster.Models
{
    public class Extensions
    {
        [MetadataType(typeof(EngMasterMetaData))]

        public partial class EngMaster { 
        
        }

        public class EngMasterMetaData
        {

            [UIHint("YesNo")]
            public Nullable<bool> Activestatus { get; set; }

        }
    }
}