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
        public int? PI { get; set; }
        public int? LeadApplicant { get; set; }
        public int? Faculty { get; set; }
        public bool LIDA { get; set; }
        public bool DSPT { get; set; }
        public bool ISO27001 { get; set; }
        public bool Azure { get; set; }
        public bool IRC { get; set; }
        public bool SEED { get; set; }

        /// <summary>
        /// Here's an Equals override so that the values contained in two instances of this class 
        /// can be compared all at once. Followed by a pair of Operator overrides that call this.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is ProjectModel))
                return false;
            
            var other = obj as ProjectModel;

            if (ProjectNumber != other.ProjectNumber
                || ProjectName != other.ProjectName
                || Stage != other.Stage
                || Classification != other.Classification
                || DATRAG != other.DATRAG
                || ProjectedStartDate != other.ProjectedStartDate
                || ProjectedEndDate != other.ProjectedEndDate
                || StartDate != other.StartDate
                || EndDate != other.EndDate
                || PI != other.PI
                || LeadApplicant != other.LeadApplicant
                || Faculty != other.Faculty
                || LIDA != other.LIDA
                || DSPT != other.DSPT
                || ISO27001 != other.ISO27001
                || Azure != other.Azure
                || IRC != other.IRC
                || SEED != other.SEED)
                return false;

            return true;
        }

        public static bool operator ==(ProjectModel x, ProjectModel y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(ProjectModel x, ProjectModel y)
        {
            return !(x==y);
        }
    }
}
