using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.Core.Resources
{
    public class ScheduleOptions
    {
        public int ShiftsPerPeriod { get; set; }

        public int ShiftDays { get; set; }

        public int ShiftsPerEngineerPerPeriod { get; set; }
    }
}
