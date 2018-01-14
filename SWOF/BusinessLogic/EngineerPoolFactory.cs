using SWOF.Core.Contract;
using SWOF.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.BusinessLogic
{
    public class EngineerPoolFactory : IEngineerPoolFactory
    {
        private readonly IEngineerRepository _engineerRepository;
        private readonly IRandomAdapter _randomAdapter;

        public EngineerPoolFactory(IEngineerRepository engineerRepository,
            IRandomAdapter randomAdapter)
        {
            _randomAdapter = randomAdapter;
            _engineerRepository = engineerRepository;
        }

        /// <summary>
        /// Creates a pool, populated with the engineers names.
        /// If each engineer needs to perform 2 shifts per period, then their
        /// names need to go into the hat 2 times each.
        /// </summary>
        /// <param name="shiftsPerEngineerPerPeriod">Number of shifts per engineer in a period</param>
        /// <returns>The created engineer pool</returns>
        public IEngineerPool Create(int shiftsPerEngineerPerPeriod)
        {
            var pool = new EngineerPool(_randomAdapter);
            var engineers = _engineerRepository.ReadAll().ToList();
            for (int i = 0; i < shiftsPerEngineerPerPeriod; i++)
            {
                pool.Add(engineers);
            }
            return pool;
        }
    }
}
