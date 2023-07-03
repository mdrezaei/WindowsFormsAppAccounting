using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2_Accounting_Utilities
{
    public static class ExDateConvertor
    {
        public static string GreCal (this DateTime value)
        {
            GregorianCalendar GreC = new GregorianCalendar();
            return GreC.GetDayOfMonth(value).ToString("00") + "-" + GreC.GetMonth(value).ToString("00") + "-" +
                GreC.GetYear(value);
        }

        public static DateTime ToMiladi(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new PersianCalendar());
        }
    }
}
