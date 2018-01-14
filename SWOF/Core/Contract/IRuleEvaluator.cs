using SWOF.Core.Resources;
using System.Collections.Generic;

namespace SWOF.Core.Contract
{
    public interface IRuleEvaluator
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
