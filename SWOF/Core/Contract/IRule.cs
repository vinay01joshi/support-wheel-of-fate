using SWOF.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.Core.Contract
{
    public interface IRule
    {
        /// <summary>
        /// Determines if the rule is valid given the passed parameters
        /// </summary>
        /// <param name="shiftId">Identifier of the proposed shift</param>
        /// <param name="candidateId">Identifier of the proposed candiate</param>
        /// <param name="shifts">Curent schedule to shifts</param>
        /// <returns>True if rule passed against passed criteria</returns>
        bool IsValid(int shiftId, int candidateId, List<Shift> shifts);
    }
}
