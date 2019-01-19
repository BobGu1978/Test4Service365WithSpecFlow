using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTSF.Util
{
    class OrderDetail
    {
        private static int count;
        private static List<String> servicename;
        private static List<int> dateadd;
        private static List<int> hour;
        private static List<int> minute;

        public static void init()
        {
            servicename = new List<string>();
            dateadd = new List<int>();
            hour = new List<int>();
            minute = new List<int>();

            ISheet sheet = OpenSheet.GetSheetWithName("Order");
            count = sheet.LastRowNum;
            for (int row = 1; row <= count; row++)
            {
                if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                {
                    servicename.Add(sheet.GetRow(row).GetCell(0).StringCellValue.Trim());
                    dateadd.Add(Convert.ToInt32(sheet.GetRow(row).GetCell(1).NumericCellValue));
                    hour.Add(Convert.ToInt32(sheet.GetRow(row).GetCell(2).NumericCellValue));
                    minute.Add(Convert.ToInt32(sheet.GetRow(row).GetCell(3).NumericCellValue));
                }
            }
        }

        public static int NumberOfAllPair()
        {
            return count;
        }

        public static String ServiceName
        {
            get
            {
                return servicename[count - 1];
            }
        }

        public static int DateAdd
        {
            get
            {
                return dateadd[count - 1];
            }
        }

        public static int Hour
        {
            get
            {
                return hour[count - 1];
            }
        }

        public static int Minute
        {
            get
            {
                return minute[count - 1];
            }
        }
    }
}
