using SWOF.Core.Contract;
using SWOF.Core.Resources;
using System.Collections.Generic;

namespace SWOF.BusinessLogic
{
    public class SequentialFillScheduleStrategy : IScheduleStrategy
    {
        private IRuleEvaluator _ruleEvaluator;

        public SequentialFillScheduleStrategy(IRuleEvaluator ruleEvaluator)
        {
            _ruleEvaluator = ruleEvaluator;
        }

        public List<Shift> Generate(IEngineerPool engineerPool, int shiftsPerPeriod)
        {
            EngineerModel candidate;
            var shifts = new List<Shift>();

            // Walk throught the shift slots and find a valid engineer for this slot
            for (int i = 0; i < shiftsPerPeriod; i++)
            {
                bool foundSuitableCandiate = false;

                while (!foundSuitableCandiate && ((candidate = engineerPool.PullRandom()) != null))
                {
                    foundSuitableCandiate = _ruleEvaluator.IsValid(i, candidate.Id, shifts);
                    if (foundSuitableCandiate)
                    {
                        shifts.Add(new Shift(i) { Engineer = candidate });
                        engineerPool.Remove(candidate);
                        engineerPool.ResetPullables();
                    }
                }
            }
            return shifts;
        }
    }
}
