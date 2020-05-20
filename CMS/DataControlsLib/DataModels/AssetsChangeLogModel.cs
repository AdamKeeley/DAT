using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class AssetsChangeLogModel
    {
        public int ChangeID { get; set; }
        public int RequestID { get; set; }
        public int AssetID { get; set; }
        public bool? ChangeAccepted { get; set; }
        public string RejectionNotes { get; set; }
    }
}
