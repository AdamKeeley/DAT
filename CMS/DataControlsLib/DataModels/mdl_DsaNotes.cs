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


        /// <summary>
        /// Equals override so that the values contained in two instances of this class 
        /// can be compared all at once.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is mdl_DsaNotes)) return false;
            var other = obj as mdl_DsaNotes;
            return Note == other.Note && Created.Value.ToString() == other.Created.Value.ToString();
        }

        /// <summary>
        /// Operator override for == that calls Equals override for this class so that the values contained 
        /// in two instances of this class can be compared all at once.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(mdl_DsaNotes x, mdl_DsaNotes y)
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
        public static bool operator !=(mdl_DsaNotes x, mdl_DsaNotes y)
        {
            return !(x == y);
        }
    }
}
