using DataControlsLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS
{
    public class DSA
    {
        public DataSet GetDsaData()
        {
            DataSet ds = new DataSet("DSAs");

            SQL_Stuff conString = new SQL_Stuff();
            using (SqlConnection connection = new SqlConnection(conString.getString()))
            {
                GetDB.GetDataTable(connection, ds, "tblDsas",
                    "SELECT DsaID, DataOwner, AmendmentOf, DsaName, DsaFileLoc, StartDate, ExpiryDate, DSPT, ISO27001, DateAdded, LastUpdated FROM dbo.tblDsas");
                GetDB.GetDataTable(connection, ds, "tblDsaNotes",
                    "SELECT dnID, Dsa, Note, Created, CreatedBy FROM dbo.tblDsaNotes");
                GetDB.GetDataTable(connection, ds, "tblDsasProjects",
                    "SELECT dpID, DsaID, Project, DateAdded FROM dbo.tblDsasProjects");
                GetDB.GetDataTable(connection, ds, "tblDsaDataOwners",
                    "SELECT doID, RebrandOf, DataOwnerName FROM dbo.tblDsaDataOwners");
                GetDB.GetDataTable(connection, ds, "tblProject",
                    "SELECT * FROM dbo.tblProject WHERE ValidTo IS NULL");
                // Add asset register stuff?
            }

            // Relations not needed due to LINQ joins, but at least they help enforce the schema
            ds.Relations.Add("AmendmentOf_DsaID_",
                    parentColumn: ds.Tables["tblDsas"].Columns["DsaID"],
                    childColumn: ds.Tables["tblDsas"].Columns["AmendmentOf"]);
            ds.Relations.Add("Dsas_DsaDataOwners",
                    parentColumn: ds.Tables["tblDsaDataOwners"].Columns["doID"],
                    childColumn: ds.Tables["tblDsas"].Columns["DataOwner"]);
            ds.Relations.Add("DsasProjects_Dsas",
                    parentColumn: ds.Tables["tblDsas"].Columns["DsaID"],
                    childColumn: ds.Tables["tblDsasProjects"].Columns["DsaID"]);
            ds.Relations.Add("RebrandOf_doID",
                    parentColumn: ds.Tables["tblDsaDataOwners"].Columns["doID"],
                    childColumn: ds.Tables["tblDsaDataOwners"].Columns["RebrandOf"]);

            return ds;
        }
    }
}
