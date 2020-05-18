using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.ViewModels
{
    public class AssetHistoryViewModel
    {
        public string Project { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string ChangeType { get; set; }
        public string AssetName { get; set; }
        public string FilePath { get; set; }
        public string Checksum { get; set; }
        public bool? ChangeAccepted { get; set; }
        public string RequestedBy { get; set; }
        public string ChangedBy { get; set; }
    }
}
