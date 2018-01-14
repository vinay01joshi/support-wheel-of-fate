using SWOF.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.Core.Contract
{
    public interface IScheduleGeneratorService
    {
        /// <summary>
        /// Generates a new schedule with the specificed parameters
        /// </summary>
        /// <param name="shiftsPerPeriod">The number of shifts per period</param>
        /// <param name="shiftsPerEngineerPerPeriod">The number of shifts per engineer per period</param>
        /// <returns>Ordered list of shifts</returns>
        List<Shift> Generate(int shiftsPerPeriod, int shiftsPerEngineerPerPeriod);
    }
}
