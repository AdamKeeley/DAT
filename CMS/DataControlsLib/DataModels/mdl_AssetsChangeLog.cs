using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class mdl_AssetsChangeLog
    {
        public int ChangeID { get; set; }
        public int? RequestID { get; set; }
        public int FileID { get; set; }
        public int? TransferMethod { get; set; }
        public string TransferFrom { get; set; }
        public string TransferTo { get; set; }
        public int? DsaReviewed { get; set; }
        public bool? ChangeAccepted { get; set; }
        public string RejectionNotes { get; set; }
    }
}
