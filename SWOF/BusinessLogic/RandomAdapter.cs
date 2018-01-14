using SWOF.Core.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.BusinessLogic
{
    public class RandomAdapter : IRandomAdapter
    {
        private readonly Random _random;

        public RandomAdapter(Random random)
        {
            _random = random;
        }

        public int Next(int max)
        {
            return _random.Next(max);
        }
    }
}
