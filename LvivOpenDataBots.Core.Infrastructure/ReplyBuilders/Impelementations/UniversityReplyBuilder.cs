using System.Collections.Generic;
using LvivOpenDataBots.Core.Data.Entities.Education;
using static LvivOpenDataBots.Core.Infrastructure.Utils.TextAnalysis;
using static LvivOpenDataBots.Core.Infrastructure.Utils.WebJsonUtils;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Impelementations
{
    public class UniversityReplyBuilder : IReplyBuilder
    {

        public string BuildReply(List<string> intents, string message)
        {
            var result = DefineMatchingEntity(
                message,
                GetRecords<University>(
                    DownloadJson<University>()
                ));

            // TODO:build reply itself + checks for nulls

            return result.Name;
        }

    }
}