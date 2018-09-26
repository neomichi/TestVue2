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

        public static void GetImage64Ext(string data64, string path)
        {
            var row = "base64,";
            var index = data64.IndexOf(row, StringComparison.OrdinalIgnoreCase);
            var data=Convert.FromBase64String(data64.Substring(index + row.Length));         
            System.IO.File.WriteAllBytes(path, data);

        }



    }
}
