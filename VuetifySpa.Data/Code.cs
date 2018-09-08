using System;
using System.Collections.Generic;
using System.Text;

namespace VuetifySpa.Data
{
    public static class Code
    {
        public static long ToLong(this Guid val) 
        {
            return BitConverter.ToInt64(val.ToByteArray(), 0);              
        }
    }
}
