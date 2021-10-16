using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScanMaster.Models
{
    public class ModelDetails
    {
       
      
        public string PartName { get; set; }
      
        public Nullable<System.DateTime> CreatedDate { get; set; }

        public virtual ICollection<ModelDetails> MDetails { get; set; }
    }
}