using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class mdl_FileTransferMethods
    {
        public int MethodID { get; set; }
        public string MethodLabel { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}
