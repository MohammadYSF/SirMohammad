using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace MyBlog.Utilities
{
    public static class PersianCalender
    {

        public static string ToShamsi(this DateTime dt)
        {

            PersianCalendar pc = new PersianCalendar();
            int monthNum = pc.GetMonth(dt);
            string monthName = "";
            switch (monthNum)
            {
                case 1:
                    monthName = "فروردین";
                    break;
                case 2:
                    monthName = "اردیبهشت";
                    break;
                case 3:
                    monthName = "خرداد";
                    break;
                case 4:
                    monthName = "تیر";
                    break;
                case 5:
                    monthName = "مرداد";
                    break;
                case 6:
                    monthName = "شهریور";
                    break;
                case 7:
                    monthName = "مهر";
                    break;
                case 8:
                    monthName = "آبان";
                    break;
                case 9:
                    monthName = "آذر";
                    break;
                case 10:
                    monthName = "دی";
                    break;
                case 11:
                    monthName = "بهمن";
                    break;
                case 12:
                    monthName = "اسفند";
                    break;

            }
            return pc.GetDayOfMonth(dt).ToString() + " " + monthName + " " + pc.GetYear(dt).ToString();

        }
    }
}
