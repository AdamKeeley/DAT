using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DataControlsLib;
using DataControlsLib.DataModels;

namespace CMS
{
    public class DataIO
    {
        public DataSet GetAssetsHistory(DateTime? dateFrom = null, DateTime? dateTo = null, string projNumber = null, string vreFilePath = null)
        {
            throw new NotImplementedException();
        }
        
        /*public List<FullAssetsHistoryModel> GetAssetsHistory(
            DateTime? dateFrom = null, DateTime? dateTo = null, string projNumber = null, string vreFilePath = null
            )
        {
            SQL_Stuff conString = new SQL_Stuff();
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(conString.getString()))
            {
                conn.Open();

                var pars = new DynamicParameters();
                pars.Add(name: "@DateFrom", value: dateFrom, dbType: DbType.DateTime);
                pars.Add(name: "@DateTo", value: dateTo, dbType: DbType.DateTime);
                pars.Add(name: "@ProjectNumber", value: projNumber, dbType: DbType.String, size: 5);
                pars.Add(name: "@VreFilePath", value: vreFilePath, dbType: DbType.String, size: 200);

                return conn.Query<FullAssetsHistoryModel, AssetsRegisterModel, DataIOModel, ProjectModel, tlkAssetChangeTypeModel, FullAssetsHistoryModel>(
                    sql: "dbo.spDataIO_GetFullAssetsHistory @DateFrom, @DateTo, @ProjectNumber, @VreFilePath",
                    map: (history, reg, io, proj, tlk) => {
                        history.AssetsRegister = reg;
                        history.DataIO = io;
                        history.Project = proj;
                        history.AssetChangeTypes = tlk;
                        return history;
                    },
                    param: pars,
                    splitOn: "AssetSha256sum,ChangeDate,ProjectNumber,ChangeTypeLabel")
                    .ToList();
            }

        }*/
    }
}
