using System;
using JetBrains.Annotations;
using static System.StringComparison;

namespace LvivOpenDataBots.Core.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        [CanBeNull]
        public static (string word, string source) GetFirstMatchAndSourceBack(this string source, string toCheck, StringComparison comp = OrdinalIgnoreCase)
        {
            var sourceSplitted = source.ToWords();
            foreach (var word in sourceSplitted)
            {
                if (String.Equals(word, toCheck, comp))
                {
                    return (word, source);
                }
            }
            return (null, null);
        }
    }
}
