using System.Collections.Generic;

namespace LvivOpenDataBots.Core.Infrastructure.TextAnalysis
{
    public static class WordsToSkip
    {
        public static readonly List<string> Prepositions = new List<string>
        {
            "при", "ім.", "ім", "для", "із", "з", "імені", "та", "і", "№"
        };
    }
}