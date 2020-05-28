using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataControlsLib
{
    public static class StringExtensions
    {
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
    }
}
