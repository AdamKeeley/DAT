using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib
{
    public static class PutDB
    {
        public static int InsertBulk(DataTable dt, string tbl, SqlConnection cn, SqlTransaction tr)
        {
            int nrows = 0;

            using (SqlBulkCopy blk = new SqlBulkCopy(cn, SqlBulkCopyOptions.Default, tr))
            {
                blk.DestinationTableName = tbl;
                blk.NotifyAfter = dt.Rows.Count;
                blk.SqlRowsCopied += (s, e) => nrows = (int)e.RowsCopied;
                blk.WriteToServer(dt);
            }

            return nrows;
        }
    }
}
