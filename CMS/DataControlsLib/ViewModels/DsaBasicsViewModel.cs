using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.ViewModels
{
    public class DsaBasicsViewModel
    {
        public int DocumentID { get; set; }
        public string DataOwner { get; set; }
        public string DsaName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DataDestructionDate { get; set; }
        public string AmendmentOf { get; set; }
        public string FilePath { get; set; }
        public bool? DSPT { get; set; }
        public bool? ISO27001 { get; set; }
        public bool? RequiresEncryption { get; set; }
        public bool? NoRemoteAccess { get; set; }
    }
}
