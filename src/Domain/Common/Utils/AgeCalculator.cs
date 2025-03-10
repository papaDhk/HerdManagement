﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerdManagement.Domain.Common.Utils
{

    /**
     * https://gist.github.com/faisalman/1724253
    * Usage example:
    * ==============
    * DateTime bday = new DateTime(1987, 11, 27);
    * DateTime cday = DateTime.Today;
    * Age age = new Age(bday, cday);
    * Console.WriteLine("It's been {0} years, {1} months, and {2} days since your birthday", age.Years, age.Months, age.Days);
    */

    public static class AgeCalculator
    {
        public static string GetAge(this DateTime birthDateTime, DateTime referenceDate)
        {
            return new Age(birthDateTime, referenceDate).AgeString;
        }
    }



    public class Age
    {
        public int Years;
        public int Months;
        public int Days;

        public Age(DateTime Bday)
        {
            this.Count(Bday);
        }

        public Age(DateTime Bday, DateTime Cday)
        {
            this.Count(Bday, Cday);
        }

        public Age Count(DateTime Bday)
        {
            return this.Count(Bday, DateTime.Today);
        }

        public Age Count(DateTime Bday, DateTime Cday)
        {
            if ((Cday.Year - Bday.Year) > 0 ||
                (((Cday.Year - Bday.Year) == 0) && ((Bday.Month < Cday.Month) ||
                ((Bday.Month == Cday.Month) && (Bday.Day <= Cday.Day)))))
            {
                int DaysInBdayMonth = DateTime.DaysInMonth(Bday.Year, Bday.Month);
                int DaysRemain = Cday.Day + (DaysInBdayMonth - Bday.Day);

                if (Cday.Month > Bday.Month)
                {
                    this.Years = Cday.Year - Bday.Year;
                    this.Months = Cday.Month - (Bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
                else if (Cday.Month == Bday.Month)
                {
                    if (Cday.Day >= Bday.Day)
                    {
                        this.Years = Cday.Year - Bday.Year;
                        this.Months = 0;
                        this.Days = Cday.Day - Bday.Day;
                    }
                    else
                    {
                        this.Years = (Cday.Year - 1) - Bday.Year;
                        this.Months = 11;
                        this.Days = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Day);
                    }
                }
                else
                {
                    this.Years = (Cday.Year - 1) - Bday.Year;
                    this.Months = Cday.Month + (11 - Bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                    this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                }
            }
            else
            {
                throw new ArgumentException("Birthday date must be earlier than current date");
            }
            return this;
        }

        public string AgeString
        {
            get
            {
                string ageString = string.Empty;
                if (Years == 1 && Months == 1)
                {
                    ageString = string.Format("1 An 1 Mois");
                }
                else if (Years == 1)
                {
                    ageString = string.Format("1 An {0} Mois", Months);
                }
                else if (Years < 1 && Months == 1 && Days == 1)
                {
                    ageString = string.Format("1 Mois 1 Jour");
                }
                else if (Years < 1 && Months == 1)
                {
                    ageString = string.Format("1 Mois {0} Jours", Days);
                }
                else if (Years < 1 && Months < 1 && Days == 1)
                {
                    ageString = string.Format("{0} Jour", Days);
                }
                else if (Years < 1 && Months < 1)
                {
                    ageString = string.Format("{0} Jours", Days);
                }
                else if (Years < 1 && Days == 1)
                {
                    ageString = string.Format("{0} Mois {1} Jour", Years * 12 + Months, Days);
                }
                else if (Years < 1)
                {
                    ageString = string.Format("{0} Mois {1} Jours", Years * 12 + Months, Days);
                }
                else if (Years >= 2 && Months == 1)
                {
                    ageString = string.Format("{0} Ans {1} Mois", Years, Months);
                }
                else // if (Years >= 2 && Months != 1)
                {
                    ageString = string.Format("{0} Ans {1} Mois", Years, Months);
                }
                return ageString;
            }

        }
    }
}
