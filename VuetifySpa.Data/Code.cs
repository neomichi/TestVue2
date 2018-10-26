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

        public static void SaveBase64(string data64, string path)
        {
            var row = "base64,";
            var index = data64.IndexOf(row, StringComparison.OrdinalIgnoreCase);
            var data = Convert.FromBase64String(data64.Substring(index + row.Length));
            System.IO.File.WriteAllBytes(path, data);
        }

        /// <summary>
        /// заменить base64 на img путь
        /// </summary>
        /// <param name="id">ид модели</param>
        /// <param name="img64">масив</param>
        /// <param name="imageext">расшерение</param>
        /// <param name="rootpath">webroot path</param>
        /// <param name="folderType">"тип папки (Avatar)"</param>
        /// <returns></returns>
        public static string SaveImage64(Guid id, string img64, string imageext, string rootpath,string folderType)
        {
            ////img/avatar/2b4d3c9a-4519-414f-8d15-55c90fdf9288.jpg?v=2018102111301294


            if (img64.StartsWith("data:image", StringComparison.OrdinalIgnoreCase)) {
                var filename = string.Format("{0}{1}", id, imageext);               
                var physicalpath = System.IO.Path.Combine(rootpath, string.Format(@"img\{0}\{1}", folderType, filename));
                if (System.IO.File.Exists(physicalpath)) System.IO.File.Delete(physicalpath);
                SaveBase64(img64, physicalpath);
                return filename;
              
            } else
            {

                var start = img64.IndexOf(id.ToString());
                var length = id.ToString().Length + 4;              
                return img64.Substring(start, length);
            }
           
        }



    }
}
