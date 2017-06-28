using System.Collections.Generic;
using System.Linq;
using System.Text;
using LvivOpenDataBots.Core.Data.Entities;
using LvivOpenDataBots.Core.Data.Entities.Education;
using LvivOpenDataBots.Core.Infrastructure.Extensions;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Contract;
using LvivOpenDataBots.Core.Infrastructure.TextAnalysis;
using static LvivOpenDataBots.Core.Infrastructure.TextAnalysis.TextAnalysis;
using static LvivOpenDataBots.Core.Infrastructure.Utils.WebJsonUtils;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Impelementations
{
    public class ReplyBuilder<T> : IReplyBuilder<T>, IReplyBuilder where T : BaseEntity
    {
        public string BuildReply(List<string> intents, string message)
        {
            var lowerWordedMessage = message.ToLowerInvariant().ToWords()
                .ExceptKeyWords<T>().Except(WordsToSkip.Prepositions).ToList();
            var result = DefineMatchingEntity(
                lowerWordedMessage,
                GetRecords<T>(
                    DownloadJson<T>()
                ));

            if (result == null)
                return "На жаль, ми нічого не знайшли за цим запитом :(";

            StringBuilder sb = new StringBuilder();
            if (!intents.Contains("address") &&
                !intents.Contains("phone") &&
                !intents.Contains("email"))
            {
                sb.Append($"{result}");
            }
            else if (intents.Contains("address"))
            {
                sb.Append($"{result?.Name}, {result?.Address}");
            }
            else if (intents.Contains("phone"))
            {
                sb.Append($"{result?.Name}, {result?.PhoneNumber}");
            }
            return sb.ToString();
        }
    }
}