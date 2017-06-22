using System.Collections.Generic;
using System.Linq;
using LvivOpenDataBots.Core.Data.Entities.Education;
using LvivOpenDataBots.Core.Infrastructure.Extensions;
using LvivOpenDataBots.Core.Infrastructure.TextAnalysis;
using static LvivOpenDataBots.Core.Infrastructure.TextAnalysis.TextAnalysis;
using static LvivOpenDataBots.Core.Infrastructure.TextAnalysis.WordsToSkip;
using static LvivOpenDataBots.Core.Infrastructure.Utils.WebJsonUtils;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Impelementations
{
    public class TechLyceumReplyBuilder : IReplyBuilder
    {
        public string BuildReply(List<string> intents, string message)
        {
            var lowerWordedMessage = message.ToLowerInvariant().ToWords()
                .Except(EducationKeyWords.TechLyceum.synonims).Except(Prepositions).ToList();
            var result = DefineMatchingEntity(
                lowerWordedMessage,
                GetRecords<TechLyceum>(
                    DownloadJson<TechLyceum>()
                ));

            // TODO:build reply itself + checks for nulls

            return result.Name;
        }
    }
}