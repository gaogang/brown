using System;
using System.Collections.Generic;
using System.Linq;

namespace brown.Ext
{
    public static class RandomOrder
    {
        public static IEnumerable<TSource> Mix<TSource>(this IEnumerable<TSource> source)
        {
            if (!source.Any<TSource>())
            {
                return Enumerable.Empty<TSource>();
            }

            Random rand = new Random();
            List<TSource> mixed = source.ToList();

			int n = mixed.Count;
			while (n > 1)
			{
				n--;
				int k = rand.Next(n + 1);
				TSource value = mixed[k];
				mixed[k] = mixed[n];
				mixed[n] = value;
			}

            return mixed;
        }
    }
}
