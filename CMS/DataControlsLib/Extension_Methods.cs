using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DataControlsLib
{
    public static class Extension_Methods
    {
        /// <summary>
        /// Used to apply double buffering to DataGridViews.
        /// This reduces screen tear when scrolling through large volume data.
        /// Usage: this.dataGridView1.DoubleBuffered(true);
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="setting"></param>
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }

        public static string NullIfEmpty(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            else
            {
                return value;
            }
        }

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
