using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.Core.Contract
{
    public interface IEngineerPoolFactory
    {
        /// <summary>
        /// Creates a pool, using the number of shifts per engineer per period
        /// figure to determine how many times each engineer is put into the pool
        /// </summary>
        /// <param name="shiftsPerEngineerPerPeriod">The number of shifts per engineer per period</param>
        /// <returns>The created pool</returns>
        IEngineerPool Create(int shiftsPerEngineerPerPeriod);
    }
}
