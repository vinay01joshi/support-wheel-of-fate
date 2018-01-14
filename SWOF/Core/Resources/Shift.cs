using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.Core.Resources
{
    public class Shift
    {

        private int _id;

        public Shift(int id)
        {
            _id = id;
        }

        public int Id => _id;

        public EngineerModel Engineer { get; set; }
    }
}
