using SWOF.Core.Contract;
using SWOF.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.BusinessLogic
{
    public class EngineerPool : IEngineerPool
    {
        private IRandomAdapter _randomAdapter;

        private List<EngineerModel> _engineersAvailable;
        private List<EngineerModel> _engineersPullable;

        public EngineerPool(IRandomAdapter randomAdapter)
        {
            _engineersAvailable = new List<EngineerModel>();
            _engineersPullable = new List<EngineerModel>();
            _randomAdapter = randomAdapter;
        }

        public int Available => _engineersAvailable.Count;

        public int Pullable => _engineersPullable.Count;

        public void Add(List<EngineerModel> engineers)
        {
            _engineersAvailable.AddRange(engineers);
            _engineersPullable.AddRange(engineers);
        }

        public EngineerModel PullRandom()
        {
            if (_engineersPullable.Any())
            {
                var candidate = _engineersPullable.ElementAt(_randomAdapter.Next(_engineersPullable.Count));
                _engineersPullable.Remove(candidate);
                return candidate;
            }
            else
            {
                return null;
            }
        }

        public void Remove(EngineerModel engineer)
        {
            _engineersAvailable.Remove(engineer);
        }

        public void ResetPullables()
        {
            _engineersPullable.Clear();
            _engineersPullable.AddRange(_engineersAvailable);
        }
    }
}
