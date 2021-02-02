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
        public int DataOwner { get; set; }
        public int? AmendmentOf { get; set; }
        public string DsaName { get; set; }
        public string DsaFileLoc { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DataDestructionDate { get; set; }
        public string AgreementOwnerEmail { get; set; }
        public bool DSPT { get; set; }
        public bool ISO27001 { get; set; }
        public bool RequiresEncryption { get; set; }
        public bool NoRemoteAccess { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? ValidUntil { get; set; }
    }
}
