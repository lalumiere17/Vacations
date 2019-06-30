using System;
using System.Collections.Generic;
using System.Text;

namespace Vacations
{
    public class Vacation
    {
        private readonly static string DATE_FORMAT = "d";
        public int UserID;
        public DateTime StartDate;
        public DateTime EndDate;

        public override string ToString() => string.Format("{0} {1}-{2}",
                UserID,
                StartDate.ToString(DATE_FORMAT),
                EndDate.ToString(DATE_FORMAT));
    }
}
