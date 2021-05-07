using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class mdl_TransferRequestTypes
    {
        public int RequestTypeID { get; set; }
        public string RequestTypeLabel { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}
