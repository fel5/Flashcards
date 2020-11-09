using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards2.Extensions
{
    public static class ListExtensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            var rand = new Random();
            for (int i = list.Count-1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                T val = list[j];
                list[j] = list[i];
                list[i] = val;
            }
            return list;
        }
    }
}
