using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    /// <summary>
    /// Data model containing class variables that describe a single project laser costing record. Includes Equals (and operator) 
    /// override to compare values of class variables in two instances of this class.
    /// </summary>
    public class mdl_ProjectCosting
    {
        public  int         ProjectCostingsId   { get; set; }
        public  string      ProjectNumber       { get; set; }
        public  int         CostingType         { get; set; }
        public  DateTime    FromDate            { get; set; }
        public  DateTime    ToDate              { get; set; }
        public  decimal     LaserCompute        { get; set; }
	    public  decimal     ItsSupport          { get; set; }
	    public  decimal     FixedInfra          { get; set; }

        /// <summary>
        /// Equals override so that the values contained in two instances of this class 
        /// can be compared all at once.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is mdl_ProjectCosting))
                return false;

            var other = obj as mdl_ProjectCosting;

            if (ProjectCostingsId   != other.ProjectCostingsId
                || ProjectNumber != other.ProjectNumber        
                || CostingType   != other.CostingType          
                || FromDate      != other.FromDate             
                || ToDate        != other.ToDate              
                || LaserCompute  != other.LaserCompute        
                || ItsSupport    != other.ItsSupport          
                || FixedInfra    != other.FixedInfra)
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
        public static bool operator ==(mdl_ProjectCosting x, mdl_ProjectCosting y)
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
        public static bool operator !=(mdl_ProjectCosting x, mdl_ProjectCosting y)
        {
            return !(x == y);
        }
    }
}
