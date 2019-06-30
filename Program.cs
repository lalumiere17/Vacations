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

            using (StreamWriter sw = new StreamWriter(@"result.txt", false, System.Text.Encoding.Default))
            {
                foreach (Vacation user in depVacation)
                {
                    if (FindIntersection(user, myVacation.First()))
                    {
                        sw.WriteLine(StringWithIntersection(user, myVacation.First()));
                    }
                    else if(FindIntersection(user, myVacation.Last()))
                    {
                        sw.WriteLine(StringWithIntersection(user, myVacation.Last()));
                    }
                    else
                    {
                        sw.WriteLine(StringWithoutIntersection(user));
                    }
                }

            Console.ReadLine();

            }
        }

        static string StringWithIntersection(Vacation _user, Vacation _person)
        {
            string str = "ID " + _user.UserID.ToString()
                         + ' ' + _user.StartDate.ToString("d")
                         + '-' + _user.EndDate.ToString("d")
                         + " пересекается с "
                         + _person.StartDate.ToString("d")
                         + '-' + _person.EndDate.ToString("d");
            return str;
        }

        static string StringWithoutIntersection(Vacation _user)
        {
            string str = "ID " + _user.UserID.ToString()
                         + ' ' + _user.StartDate.ToString("d")
                         + '-' + _user.EndDate.ToString("d");
            return str;
        }

        static bool FindIntersection(Vacation _user, Vacation _person)
        {
            bool detection;
            if ((_person.StartDate <= _user.EndDate) & (_person.EndDate >= _user.EndDate))
            {
                detection = true;
            }
            else if ((_user.StartDate <= _person.EndDate) & (_user.EndDate >= _person.EndDate))
            {
                detection = true;
            }
            else
                detection = false;
            return detection;
        }
    }
}
