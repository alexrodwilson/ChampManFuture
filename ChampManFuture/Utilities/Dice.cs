using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManFuture.Utilities
{
    public class Dice
    {
        private Random _random;
        public Dice(Random random)
        {
            _random = random;
        }
        public int DieN(int n)
        {
            return _random.Next(n - 1) + 1;
        }
        
    }
}
