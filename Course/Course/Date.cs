using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    [Serializable]
    public class Date : IPrettyShowable
    {
        /// <summary>
        /// Creates Date object with specified Year, Month and Day
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="month">Month</param>
        /// <param name="day">Day</param>
        ///         public Date()
        private int day;
        private int month;
        public int Year
        {
            get;
            set;
        }

        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                month = value;
            }
        }
        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }
        public Date()
        {
            Year = 2000;
            Month = 1;
            Day = 1;
        }

        public Date(int y, int m, int d)
        {
            Year = y;
            Month = m;
            Day = d;
        }
        /// <summary>
        /// Returns new date in some days of current
        /// </summary>
        /// <param name="n">Number of days</param>
        /// <returns>New date in N days of current</returns>
        public Date AddDays(int n)
        {
            int day = Day + n;
            int month = Month + day / 31;
            int year = Year + month / 12;
            day %= 31;
            month %= 12;
            return new Date(year, month, day);
        }
        private string Line()
        {
            return "+--------------------------------------+---------------------------------------+";
        }
        public void ShowHeader()
        {
            const string title = "Дата";
            Console.WriteLine("\n{0," + (Console.WindowWidth + title.Length) / 2 + "}\n", title);
            Console.Write(Line());
            Console.Write("|   День        | Місяць  |    Рiк    |");
            Console.Write(Line());
        }
        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool pretty)
        {
            if (pretty)
                return String.Format("{0:00}/{1:00}/{2:0000}", Day, Month, Year);
            else
                return String.Format("{0:00}/{1:00}/{2:0000}", Year, Month, Day);
        }

        public static bool operator ==(Date d1, Date d2)
        {
            return d1.Year == d2.Year && d1.Month == d2.Month && d1.Day == d2.Day;
        }
        public static bool operator >(Date d1, Date d2)
        {
            if (d1.Year > d2.Year) return true;
            if (d1.Month > d2.Month) return true;
            if (d1.Day > d2.Day) return true;
            return false;
        }
        public static bool operator <(Date d1, Date d2)
        {
            return !(d1 > d2 || d1.Day == d2.Day);
        }
        public static bool operator !=(Date d1, Date d2)
        {
            return !(d1 == d2);
        }
        public static bool operator <=(Date d1, Date d2)
        {
            return !(d1 > d2);
        }
        public static bool operator >=(Date d1, Date d2)
        {
            return !(d1 < d2);
        }
        public override bool Equals(Object obj)
        {
            return obj is Date && this == (Date)obj;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Year, month,day).GetHashCode();
        }
    }

}
