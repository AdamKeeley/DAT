using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS
{
    public class SQL_Stuff
    {
        //constructor
        public SQL_Stuff()
        {
            conString = $"Data Source=GHOST\\SQLEXPRESS;Initial Catalog=DST_CMS;Integrated Security=True";
        }

        //members
        string conString { get; }
        public string getString()
        {
            return conString;
        }
    }
}
