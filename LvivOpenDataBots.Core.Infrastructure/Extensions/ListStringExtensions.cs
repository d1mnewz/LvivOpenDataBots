using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using LvivOpenDataBots.Core.Data.Entities.Education;
using LvivOpenDataBots.Core.Infrastructure.TextAnalysis;
using static System.Char;

namespace LvivOpenDataBots.Core.Infrastructure.Extensions
{
    public static class ListStringExtensions
    {
        [ItemNotNull]
        public static IList<string> ToWords(this string source)
        {
            var punctuation = source.Where(IsPunctuation).Distinct().ToArray();
            return source.Split().Select(x => x.Trim(punctuation)).Where(x => x != "").Select(x => x.Replace("№", "")).ToList();

        }

        [ItemNotNull]
        public static IEnumerable<string> ExceptKeyWords<T>(this IList<string> source) where T : BaseEducationEntity
        {
            switch (typeof(T).Name)
            {
                case "KinderGarten":
                    return source.Except(EducationKeyWords.KinderGarten.synonims);
                case "Gymnasium":
                    return source.Except(EducationKeyWords.Gymnasium.synonims);
                case "PreSchool":
                    return source.Except(EducationKeyWords.PreSchool.synonims);
                case "School":
                    return source.Except(EducationKeyWords.School.synonims);
                case "TechLyceum":
                    return source.Except(EducationKeyWords.TechLyceum.synonims);
                case "University":
                    return source.Except(EducationKeyWords.University.synonims);
                default:
                    throw new ArgumentException($"{typeof(T).Name} is not supported");
            }
        }
    }
}
