using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class mdl_AssetsRegister
    {
        public int FileID { get; set; }
        public string Project { get; set; }
        public string DataFileName { get; set; }
        //public string Sha256sum { get; set; }
        public string VreFilePath { get; set; }
        public string DataRepoFilePath { get; set; }
        public int? AssetID { get; set; }
    }
}
