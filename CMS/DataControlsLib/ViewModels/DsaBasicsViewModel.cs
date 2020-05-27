using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.ViewModels
{
    public class DsaBasicsViewModel
    {
        public string DataOwner { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string DsaName { get; set; }
        public string FilePath { get; set; }
        public string AmendmentOf { get; set; }
        public bool DSPT { get; set; }
        public bool ISO27001 { get; set; }
    }
}
