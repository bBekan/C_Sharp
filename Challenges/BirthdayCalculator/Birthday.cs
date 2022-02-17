using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCalculator
{
    internal class Birthday
    {
        public int Years { get; private set; }
        public int Months { get; private set; }
        public int Days { get; private set; }
        public int MonthsToBirthday { get; set; }
        public int WeeksToBirthday { get; set; }
        public DateTime DOB { get; set; }

        public Birthday(DateTime DOB)
        {
            this.DOB = DOB;
            Days = (int)(DateTime.Now - DOB).TotalDays;
            Years = (int)Days / 365;
            Months = CalculateMonths();
        }

        private int CalculateMonths()
        {
            var difference = DateTime.Now.Month - DOB.Month;
            if(difference < 0)
            {
                MonthsToBirthday = -difference;
                difference = 12 + difference;
            }
            MonthsToBirthday = 12 - difference;
            WeeksToBirthday = (int) (MonthsToBirthday * 4.33);
            return (int)Years * 12 + difference;
        }

    }
}
