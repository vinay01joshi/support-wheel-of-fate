using SWOF.Core.Contract;
using SWOF.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.BusinessLogic
{
    public class ConsecutiveDayRule : IRule
    {
        public bool IsValid(int shiftId, int candidateId, List<Shift> shifts)
        {
            // If shiftId is the first day then allocation must be valid
            if (shiftId < 2)
            {
                return true;
            }
            else
            {
                bool isMorning = shiftId == 0 || shiftId % 2 == 0;
                if (isMorning)
                {
                    //Proposed shift is for a morning - check the last 2 shifts are not for the same enginner
                    if (shifts[shiftId - 1].Engineer?.Id == candidateId ||
                       shifts[shiftId - 2].Engineer?.Id == candidateId)
                    {
                        return false;
                    }
                }
                else
                {
                    //Proposd shift is for an afternoon - check the previous days shifts
                    if (shifts[shiftId - 2].Engineer?.Id == candidateId ||
                        shifts[shiftId - 3].Engineer?.Id == candidateId)
                    {
                        return false;
                    }
                }

                // The same enginner is not defined for the previous day, so the proposal is valid
                return true;
            }
        }
    }
}
