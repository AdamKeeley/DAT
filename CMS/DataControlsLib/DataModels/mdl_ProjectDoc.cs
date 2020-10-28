using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    /// <summary>
    /// Data model containing class variables that describe a single project document. Includes Equals (and operator) 
    /// override to compare values of class variables in two instances of this class.
    /// </summary>
    public class mdl_ProjectDoc
    {
        public int?         pdID                { get; set; }
        public string       ProjectNumber       { get; set; }
        public int?         DocumentType        { get; set; }
        public string       DocumentType_Desc   { get; set; }
        public decimal?     VersionNumber       { get; set; }
        public DateTime?    Submitted           { get; set; }
        public DateTime?    Accepted            { get; set; }

        /// <summary>
        /// Equals override so that the values contained in two instances of this class 
        /// can be compared all at once.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is mdl_ProjectDoc))
                return false;

            var other = obj as mdl_ProjectDoc;

            if (ProjectNumber != other.ProjectNumber
                || DocumentType != other.DocumentType
                || VersionNumber != other.VersionNumber
                || VersionNumber != other.VersionNumber
                || Submitted != other.Submitted
                || Accepted != other.Accepted)
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
        public static bool operator ==(mdl_ProjectDoc x, mdl_ProjectDoc y)
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
        public static bool operator !=(mdl_ProjectDoc x, mdl_ProjectDoc y)
        {
            return !(x == y);
        }
    }
}
