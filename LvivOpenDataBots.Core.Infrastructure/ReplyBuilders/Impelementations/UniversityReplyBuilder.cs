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
    public class UniversityReplyBuilder : IReplyBuilder
    {

        public string BuildReply(List<string> intents, string message)
        {
            var lowerWordedMessage = message.ToLowerInvariant().ToWords()
                .Except(EducationKeyWords.University.synonims).Except(Prepositions).ToList();
            var result = DefineMatchingEntity(
                lowerWordedMessage,
                GetRecords<University>(
                    DownloadJson<University>()
                ));

            // TODO:build reply itself + checks for nulls

            if (result == null)
                return "На жаль, ми не знайшли ніякого університету за цим запитом :(";
            return result.Name;
        }

    }
}