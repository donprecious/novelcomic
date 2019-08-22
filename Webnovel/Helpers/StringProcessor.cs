using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Helpers
{
    public static class StringProcessor
    {
        public static string SubString(string value, int start, int stop)
        {
            if (value.Length > stop)
            {
                return value.Substring(start, stop)+ " ...";

            }

            return value.Substring(start, value.Length);
        }
    }
}
