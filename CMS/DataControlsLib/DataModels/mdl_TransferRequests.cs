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
        public int RequestType { get; set; }
        public string RequestedBy { get; set; }
        public string RequesterNotes { get; set; }
        public string ReviewedBy { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string ReviewNotes { get; set; }
    }
}
