using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace LvivOpenDataBots.Core.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        [CanBeNull]
        public static (string word, string source) GetFirstMatchAndSourceBack(this string source, string toCheck, StringComparison comp)
        {
            var sourceSplitted = source.ToWords();
            foreach (var word in sourceSplitted)
            {
                if (String.Equals(word, toCheck, StringComparison.OrdinalIgnoreCase))
                {
                    return (word, source);
                }
            }
            return (null, null);
        }
    }
}
