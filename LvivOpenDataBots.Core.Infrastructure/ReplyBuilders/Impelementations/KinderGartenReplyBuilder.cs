using System.Collections.Generic;
using LvivOpenDataBots.Core.Data.Entities.Education;
using LvivOpenDataBots.Core.Infrastructure.Utils;
using static LvivOpenDataBots.Core.Infrastructure.Utils.WebJsonUtils;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Impelementations
{
    public class KinderGartenReplyBuilder : IReplyBuilder
    {
        public string BuildReply(List<string> intents, string message)
        {
            var result = TextAnalysis.DefineMatchingEntity(
                message,
                GetRecords<KinderGarten>(
                    DownloadJson<KinderGarten>()
                    ));

           // TODO:build reply itself

            return result.Name;
        }
    }
}
