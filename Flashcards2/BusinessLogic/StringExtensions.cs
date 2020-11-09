using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards2.Extensions
{
    public static partial class Extensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
