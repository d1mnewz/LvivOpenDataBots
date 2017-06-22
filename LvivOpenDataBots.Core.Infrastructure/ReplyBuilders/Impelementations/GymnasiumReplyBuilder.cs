using System.Collections.Generic;
using LvivOpenDataBots.Core.Data.Entities.Education;
using LvivOpenDataBots.Core.Infrastructure.Utils;
using static LvivOpenDataBots.Core.Infrastructure.Utils.WebJsonUtils;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Impelementations
{
    public class GymnasiumReplyBuilder : IReplyBuilder
    {
        public string BuildReply(List<string> intents, string message)
        {
            var result = TextAnalysis.DefineMatchingEntity(
                message,
                GetRecords<Gymnasium>(
                    DownloadJson<Gymnasium>()
                ));

            // TODO:build reply itself + checks for nulls

            return result.Name;
        }
    }
}