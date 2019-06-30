using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Vacations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vacation> myVacation = new List<Vacation>();
            for (int i = 0; i < 2; i++)
            {
                Vacation newOne = new Vacation();
                newOne = RandomVacationGenerator.RandVacation();
                newOne.UserID = 1;
                myVacation.Add(newOne);
            }

            List<Vacation> depVacation = new List<Vacation>();
            for (int i = 0; i < 1000; i++)
            {
                Vacation newOne = new Vacation();
                newOne = RandomVacationGenerator.RandVacation();
                depVacation.Add(newOne);
            }

            var result = depVacation
                    .Select(vacation =>
                    {
                        if (FindIntersection(vacation, myVacation.First()))
                            return StringWithIntersection(vacation, myVacation.First()) + "\n";
                        else if (FindIntersection(vacation, myVacation.Last()))
                            return StringWithIntersection(vacation, myVacation.Last()) + "\n";
                        else return StringWithoutIntersection(vacation) + "\n";
                    })
                    .ToArray();

            var stringResult = string.Join(string.Empty, result);

            using (StreamWriter sw = new StreamWriter(@"result.txt", false, System.Text.Encoding.Default))
            {
                sw.Write(stringResult);
            }
   
        }

        static string StringWithIntersection(Vacation _user, Vacation _person) =>
            string.Format("ID {0} пересекается с {1}-{2}", _user.ToString(), _person.StartDate.ToString("d"),
                _person.EndDate.ToString("d"));
        
        static string StringWithoutIntersection(Vacation _user) => 
            string.Format("ID {0}", _user.ToString());

        static bool FindIntersection(Vacation _user, Vacation _person) => 
            ((_person.StartDate <= _user.EndDate) & (_person.EndDate >= _user.EndDate)) ||
            ((_user.StartDate <= _person.EndDate) & (_user.EndDate >= _person.EndDate));
    }
}
