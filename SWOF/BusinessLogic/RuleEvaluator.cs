using SWOF.Core.Contract;
using SWOF.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.BusinessLogic
{
    public class RuleEvaluator : IRuleEvaluator
    {
        private readonly IList<IRule> _rules;

        public RuleEvaluator(IList<IRule> rules)
        {
            _rules = rules;
        }

        public bool IsValid(int shiftId, int candidateId, List<Shift> shifts)
        {
            var valid = true;
            // Check if all the rules pass
            foreach (var rule in _rules)
            {
                valid &= rule.IsValid(shiftId, candidateId, shifts);
            }

            return valid;
        }
    }
}
