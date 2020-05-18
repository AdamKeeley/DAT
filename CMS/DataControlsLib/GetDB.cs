using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib
{
    public static class GetDB
    {
        public static void GetDataTable(SqlConnection cnn, DataSet dsObj, string tblName, string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand qry = new SqlCommand();
            qry.CommandText = sql;
            qry.Connection = cnn;
            da.SelectCommand = qry;
            da.Fill(dsObj, tblName);
        }
    }
}
