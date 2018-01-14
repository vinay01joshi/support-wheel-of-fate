using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.Core.Contract
{
    public interface IRandomAdapter
    {
        int Next(int max);
    }
}
