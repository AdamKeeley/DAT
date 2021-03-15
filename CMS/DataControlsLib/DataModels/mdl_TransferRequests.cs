using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class mdl_TransferRequests
    {
        public int RequestID { get; set; }
        public string Project { get; set; }
        public string VreNumber { get; set; }
        public int RequestType { get; set; }
        public int RequestedBy { get; set; }
        public string RequesterNotes { get; set; }
        public int ReviewedBy { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string ReviewNotes { get; set; }
    }
}
