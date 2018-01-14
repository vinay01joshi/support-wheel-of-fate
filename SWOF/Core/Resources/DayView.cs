using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.Core.Resources
{
    public class DayView
    {
        public string Name { get; set; }

        public List<Shift> Shifts { get; set; }

        public int WeekNumber { get; set; }
    }
}
