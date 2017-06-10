using System;
using System.Collections.Generic;
using System.Linq;

namespace brown.Ext
{
    public static class RandomElement
    {
        public static TSource Rand<TSource>(this IEnumerable<TSource> sources)
        {
            Random randGen = new Random();

            int id = randGen.Next(sources.Count<TSource>());

            return sources.ElementAt<TSource>(id);
        }
    }
}
