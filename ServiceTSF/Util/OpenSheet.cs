using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace ServiceTSF.Util
{
    class OpenSheet
    {
        public static ISheet GetSheetWithName(String name)
        {
            HSSFWorkbook hssfwb;
            Uri UriAssemblyFolder = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly()
              .GetName().CodeBase));
            string path = UriAssemblyFolder.LocalPath;
            path = path + @"..\..\..\testdata.xls";
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
            }
            return hssfwb.GetSheet(name);
        }
    }
}
