using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.ViewModels
{
    public class AssetHistoryViewModel
    {
        public string Project { get; set; }
        public string DataOwner { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string RequestType { get; set; }
        public string FileName { get; set; }
        public string AssetGroup { get; set; }
        public string FilePath { get; set; }
        public string RepoPath { get; set; }
        public string Checksum { get; set; }
        public string TransferMethod { get; set; }
        public string TransferFrom { get; set; }
        public string TransferTo { get; set; }
        public string RequestedBy { get; set; }
        public string DsaReviewed { get; set; }
        public string ReviewedBy { get; set; }
        public bool? ChangeAccepted { get; set; }
    }
}
