using SWOF.Core.Contract;
using SWOF.Core.Resources;
using System.Collections.Generic;
using System.Linq;

namespace SWOF.BusinessLogic
{
    public class ScheduleGeneratorService : IScheduleGeneratorService
    {
        private readonly IEngineerPoolFactory _engineerPoolFactory;
        private readonly IScheduleStrategy _scheduleStrategy;

        public ScheduleGeneratorService(IEngineerPoolFactory engineerPoolFactory,
         IScheduleStrategy scheduleStrategy)
        {
            _engineerPoolFactory = engineerPoolFactory;
            _scheduleStrategy = scheduleStrategy;
        }

        /// <summary>
        /// Generates a schedule. Due to nature of the Random engineer picking, it sometimes
        /// picks the engineers in such a way that there is no valid way to populate all the shifts
        /// In this case we just have another go with a new Random object.
        /// For example, an engineer may not get picked until the 19th slot which is valid, but then
        /// the same engineer cannot be used in the remaining slot.
        /// </summary>
        /// <param name="shiftsPerPeriod">Number of shifts per period</param>
        /// <param name="shiftsPerEngineerPerPeriod">Number of shifts per engineer per period</param>
        /// <returns>Ordered list of shifts with allocated engineer</returns>
        public List<Shift> Generate(int shiftsPerPeriod, int shiftsPerEngineerPerPeriod)
        {
            var shifts = new List<Shift>();
            while (shifts.Count(x => x.Engineer != null) != shiftsPerPeriod)
            {
                // Create a pool of engineers to use for scheduling
                var engineerPool = _engineerPoolFactory.Create(shiftsPerEngineerPerPeriod);

                // Generate the shift pattern using the provided strategy
                shifts = _scheduleStrategy.Generate(engineerPool, shiftsPerPeriod);
            }
            return shifts;
        }
    }
}
