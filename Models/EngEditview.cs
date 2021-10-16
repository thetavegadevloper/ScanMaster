using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScanMaster.Models
{
    public class EngEditview
    {
        public int ID { get; set; }
        public string Vcode { get; set; }

       
        public string ModelName { get; set; }

      
        public string ModelCode { get; set; }


        public Nullable<System.DateTime> UpdatesDateTime { get; set; }
        public string UpdateNo { get; set; }

        [UIHint("YesNo")]
        public Nullable<bool> Activestatus { get; set; }
    }
}