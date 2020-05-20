using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class DsasProjects
    {
        public int dpID { get; set; }
        public int DsaID { get; set; }
        public string Project { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
