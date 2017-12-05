using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManFuture.Utilities
{
    public static class GeneralUtils
    {
        public static T PickRandom<T>(IEnumerable<T> xs, Random random)
        {
            int randomIndex = random.Next(xs.Count());
            return xs.ElementAt(randomIndex);
        }
        private static List<T> Shuffle<T>(IList<T> list, Random rng)
        {
            List<T> newList = new List<T>();
            foreach (T t in list)
            {
                newList.Add(t);
            }
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = newList[k];
                newList[k] = newList[n];
                newList[n] = value;
            }
            return newList;
        }
    }
}

