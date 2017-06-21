using System;
using System.Collections.Generic;
using System.Linq;

namespace LvivOpenDataBots.Core.Infrastructure.Extensions
{
    public static class StringExtensions
    {

        public static IList<string> ToWords(this string source)
        {
            var punctuation = source.Where(Char.IsPunctuation).Distinct().ToArray();
            return source.Split().Select(x => x.Trim(punctuation)).Where(x => x != "").ToList();

        }

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
