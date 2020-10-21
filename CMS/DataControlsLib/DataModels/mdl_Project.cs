using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    /// <summary>
    /// Data model containing class variables that describe a single project. Includes Equals (and operator) 
    /// override to compare values of class variables in two instances of this class.
    /// </summary>
    public class mdl_Project
    {
        public int pID { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public string PortfolioNumber { get; set; }
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
        public bool LASER { get; set; }
        public bool IRC { get; set; }
        public bool SEED { get; set; }

        /// <summary>
        /// Equals override so that the values contained in two instances of this class 
        /// can be compared all at once.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is mdl_Project))
                return false;
            
            var other = obj as mdl_Project;

            if (ProjectNumber != other.ProjectNumber
                || ProjectName != other.ProjectName
                || PortfolioNumber != other.PortfolioNumber
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
                || LASER != other.LASER
                || IRC != other.IRC
                || SEED != other.SEED)
                return false;

            return true;
        }

        /// <summary>
        /// Operator override for == that calls Equals override for this class so that the values contained 
        /// in two instances of this class can be compared all at once.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(mdl_Project x, mdl_Project y)
        {
            return x.Equals(y);
        }

        /// <summary>
        ///Operator override for != that calls Equals override for this class so that the values contained 
        /// in two instances of this class can be compared all at once.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(mdl_Project x, mdl_Project y)
        {
            return !(x==y);
        }
    }
}
