using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ServiceTSF.Util
{
    class CustomerData
    {
        private static List<String> username;

        private static List<String> password;

        private static int count;

        public static void init()
        {
            username = new List<string>();
            password = new List<string>();

            ISheet sheet = OpenSheet.GetSheetWithName("Customer");
            count = sheet.LastRowNum;
            int i_user = 0;
            int i_pwd=1;
            if (sheet.GetRow(0) != null)
            {
                if(sheet.GetRow(0).GetCell(0).StringCellValue.Trim().Equals("UserName"))
                {
                    i_user = 0;
                    i_pwd = 1;
                }
                else
                {
                    i_user = 1;
                    i_pwd = 0;
                }
            }
            for (int row = 1; row <= count; row++)
            {
                if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                {
                     username.Add(sheet.GetRow(row).GetCell(i_user).StringCellValue.Trim());
                     password.Add(sheet.GetRow(row).GetCell(i_pwd).StringCellValue.Trim());
                }
            }
        }

        public static int NumberOfAllPair()
        {
            return count;
        }

        //let's just return the last one of the username
        public static String UserName
        {
            get
            {
                return username[count - 1];
            }
        }

        //let's just return the last one of the password just like what we do for username
        public static String Pwd
        {
            get
            {
               return password[count - 1];
            }
        }
    }
}
