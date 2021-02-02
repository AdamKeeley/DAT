using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class mdl_DsaNotes
    {
        public int dnID { get; set; }
        public int Dsa { get; set; }
        public string Note { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedBy { get; set; }
    }
}
