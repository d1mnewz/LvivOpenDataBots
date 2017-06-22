using System.Collections.Generic;
using System.Linq;
using LvivOpenDataBots.Core.Data.Entities.Education;
using LvivOpenDataBots.Core.Infrastructure.Extensions;
using LvivOpenDataBots.Core.Infrastructure.TextAnalysis;
using static LvivOpenDataBots.Core.Infrastructure.TextAnalysis.TextAnalysis;
using static LvivOpenDataBots.Core.Infrastructure.Utils.WebJsonUtils;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Impelementations
{
    public class GymnasiumReplyBuilder : IReplyBuilder
    {
        public string BuildReply(List<string> intents, string message)
        {
            var lowerWordedMessage = message.ToLowerInvariant().ToWords()
                .Except(EducationKeyWords.Gymnasium.synonims).Except(WordsToSkip.Prepositions).ToList();
            var result = DefineMatchingEntity(
                lowerWordedMessage,
                GetRecords<Gymnasium>(
                    DownloadJson<Gymnasium>()
                ));

            // TODO:build reply itself + checks for nulls

            return result.Name;
        }
    }
}