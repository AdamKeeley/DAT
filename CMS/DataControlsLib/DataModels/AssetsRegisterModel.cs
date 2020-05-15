using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib.DataModels
{
    public class AssetsRegisterModel
    {
        public int AssetID { get; set; }
        public int Project { get; set; }
        public string AssetName { get; set; }
        public string AssetSha256sum { get; set; }
        public string VreFilePath { get; set; }
    }
}
