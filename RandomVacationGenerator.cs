using System;
using System.Collections.Generic;
using System.Text;


namespace Vacations
{
    public class RandomVacationGenerator
    {
        public static DateTime MakeRandomDate()
        {
            Random rand = new Random();
            int randDay = rand.Next(1, 30);
            int randMonth = rand.Next(1, 12);
            DateTime randomStartVacation = new DateTime(2020, randMonth, randDay);
            return randomStartVacation;
        }
        
        public static Vacation RandVacation()
        {
            DateTime makeDate = MakeRandomDate();
            Random randInt = new Random();
            Vacation item = new Vacation
            {
                StartDate = makeDate,
                EndDate = makeDate.AddDays(14),
                UserID = randInt.Next(2, 1001)
            };
            return item;
        }
    }
}