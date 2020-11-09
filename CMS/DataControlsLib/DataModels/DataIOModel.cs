using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class DataIOModel
    {
        public int RequestID { get; set; }
        public int Project { get; set; }
        public int ChangeType { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string RequestedBy { get; set; }
        public string RequesterNotes { get; set; }
        public string ReviewedBy { get; set; }
        public string ReviewNotes { get; set; }
    }
}
