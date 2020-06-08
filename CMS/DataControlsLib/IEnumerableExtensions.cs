using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib
{
    public static class IEnumerableExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> input)
            where T : class
        {
            DataTable output = new DataTable();

            if (input.Count() == 0)
            {
                return output;
            }

            //get the list of  public properties and add them as columns to the output table           
            PropertyInfo[] prop = input.FirstOrDefault().GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in prop)
            {
                output.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
            }

            DataRow dr;
            //iterate through all the objects in the list and add them as rows to the table
            foreach (T t in input)
            {
                dr = output.NewRow();
                //iterate through all the properties of the current object and set their values to data row
                foreach (PropertyInfo p in prop)
                {
                    dr[p.Name] = p.GetValue(t) == null ? (object)DBNull.Value : (object)p.GetValue(t);
                }
                output.Rows.Add(dr);
            }
            return output;
        }
    }
}
