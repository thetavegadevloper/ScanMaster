using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScanMaster.Models
{
    public class EngInsertView
    {
        [Required(ErrorMessage = "Code Required")]
        public string Barcode { get; set; }

        [Required(ErrorMessage = "ModelName Required")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "ModelCode Required")]
        public string ModelCode { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }

        [UIHint("YesNo")]
        public Nullable<bool> Activestatus { get; set; }
    }
}