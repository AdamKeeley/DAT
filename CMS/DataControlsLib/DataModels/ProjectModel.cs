using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class ProjectModel
    {
        public int pID { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public int? Stage { get; set; }
        public int? Classification { get; set; }
        public int? DATRAG { get; set; }
        public DateTime? ProjectedStartDate { get; set; }
        public DateTime? ProjectedEndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PI { get; set; }
        public string LeadApplicant { get; set; }
        public int? Faculty { get; set; }
        public bool? LIDA { get; set; }
        public bool? DSPT { get; set; }
        public bool? ISO27001 { get; set; }
        public bool? Azure { get; set; }
        public bool? IRC { get; set; }
        public bool? SEED { get; set; }
    }
}
