using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class mdl_Dsas
    {
        public int DsaID { get; set; }
        public int ID { get; set; }
        public int DataOwner { get; set; }
        public int? AmendmentOf { get; set; }
        public string DsaName { get; set; }
        public string DsaFileLoc { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DataDestructionDate { get; set; }
        public string AgreementOwnerEmail { get; set; }
        public bool? DSPT { get; set; }
        public bool? ISO27001 { get; set; }
        public bool? RequiresEncryption { get; set; }
        public bool? NoRemoteAccess { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool Deprecated { get; set; }


        /// <summary>
        /// Equals override so that the values contained in two instances of this class 
        /// can be compared all at once.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is mdl_Dsas)) return false;
            var other = obj as mdl_Dsas;

            // Handle nulls in dates before making comparisons
            string thisSD = StartDate.HasValue ? StartDate.Value.ToString() : null;
            string otherSD = other.StartDate.HasValue ? other.StartDate.Value.ToString() : null;
            string thisED = ExpiryDate.HasValue ? ExpiryDate.Value.ToString() : null;
            string otherED = other.ExpiryDate.HasValue ? other.ExpiryDate.Value.ToString() : null;
            string thisDD = DataDestructionDate.HasValue ? DataDestructionDate.Value.ToString() : null;
            string otherDD = other.DataDestructionDate.HasValue ? other.DataDestructionDate.Value.ToString() : null;

            return (ID == other.ID &&
                    DataOwner == other.DataOwner &&
                    AmendmentOf == other.AmendmentOf &&
                    DsaName == other.DsaName &&
                    DsaFileLoc == other.DsaFileLoc &&
                    thisSD == otherSD &&
                    thisED == otherED &&
                    thisDD == otherDD &&
                    AgreementOwnerEmail == other.AgreementOwnerEmail &&
                    DSPT == other.DSPT &&
                    ISO27001 == other.ISO27001 &&
                    RequiresEncryption == other.RequiresEncryption &&
                    NoRemoteAccess == other.NoRemoteAccess);
        }

        /// <summary>
        /// Operator override for == that calls Equals override for this class so that the values contained 
        /// in two instances of this class can be compared all at once.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(mdl_Dsas x, mdl_Dsas y)
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
        public static bool operator !=(mdl_Dsas x, mdl_Dsas y)
        {
            return !(x == y);
        }
    }
}
