using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectIdeas
{
    public class RandomGenerator
    {
        public static string GetRandomProjectName()
        {
            System.Random rnd = new System.Random();
            int randomNumber = rnd.Next(10);

            return randomNumber.ToString(); ;
        }

        static DateTime GetRandomDateFromDateToNow(int year, int month, int day)
        {
            // Check if values for month and day are allowed.
            string date = $"{year}-{month}-{day}";



            if (month > 0 && month < 13 && day > 0 && day < 32)
            {
                DateTime startDate = new DateTime(year, month, day);
                Random rnd = new Random();
                int range = ((TimeSpan)(DateTime.Today - startDate)).Days;
                DateTime randomDate = startDate.AddDays(rnd.Next(range));
                return randomDate;
            }
            else
            {
                return new DateTime(0, 1, 1);
            }
        }

        static DateTime GetRandomDateFromNowToDate(int year, int month, int day)
        {
            // Check if values for month and day are allowed.
            if (month > 0 && month < 13 && day > 0 && day < 32)
            {
                DateTime endDate = new DateTime(year, month, day);
                Random rnd = new Random();
                int range = ((TimeSpan)(endDate - DateTime.Today)).Days;
                DateTime randomDate = endDate.AddDays(-rnd.Next(range));
                return randomDate;
            }
            else
            {
                return new DateTime(0, 1, 1);
            }
        }

        static DateTime GetRandomDateFromDateToDate(int firstYear, int firstMonth, int firstDay, int secondYear, int secondMonth, int secondDay)
        {
            // Check if values for month and day are allowed.
            //if (firstMonth > 0 && firstMonth < 13 && firstDay > 0 && firstDay < 32)
            //{
            //    DateTime endDate = new DateTime(year, month, day);
            //    Random rnd = new Random();
            //    int range = ((TimeSpan)(endDate - DateTime.Today)).Days;
            //    DateTime randomDate = endDate.AddDays(-rnd.Next(range));
            //    return randomDate;
            //}
            //else
            //{
                return new DateTime(0, 1, 1);
            //}
        }



        //public static string GetRandomFrontendTech()
        //{

        //}

        //public static string GetRandomBackendTech()
        //{

        //}

        //public static string GetRandomDate()
        //{

        //}
    }
}
