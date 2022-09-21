using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    /// <summary>
    /// Data model containing class variables that describe a single project dat allocation record. Includes Equals (and operator) 
    /// override to compare values of class variables in two instances of this class.
    /// </summary>
    public class mdl_ProjectDatAllocation
    {
        public string       ProjectNumber   { get; set; }
        public DateTime     FromDate        { get; set; }
        public DateTime     ToDate          { get; set; }
        public decimal      FTE             { get; set; }

        /// <summary>
        /// Equals override so that the values contained in two instances of this class 
        /// can be compared all at once.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is mdl_ProjectDatAllocation))
                return false;

            var other = obj as mdl_ProjectDatAllocation;

            if (ProjectNumber != other.ProjectNumber
                || FromDate != other.FromDate
                || ToDate != other.ToDate
                || FTE != other.FTE)
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
        public static bool operator ==(mdl_ProjectDatAllocation x, mdl_ProjectDatAllocation y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Operator override for != that calls Equals override for this class so that the values contained 
        /// in two instances of this class can be compared all at once.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(mdl_ProjectDatAllocation x, mdl_ProjectDatAllocation y)
        {
            return !(x == y);
        }
    }
}
