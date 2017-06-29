using System.Collections.Generic;
using System.Linq;
using System.Text;
using LvivOpenDataBots.Core.Data.Entities;
using LvivOpenDataBots.Core.Infrastructure.Extensions;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Contract;
using LvivOpenDataBots.Core.Infrastructure.TextAnalysis;
using LvivOpenDataBots.Core.Infrastructure.Utils;
using static LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Impelementation.Errors;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Impelementation
{
    public class ReplyBuilder<T> : IReplyBuilder<T>, IReplyBuilder where T : BaseEducationEntity
    {
        public string BuildReply(List<string> intents, string message)
        {
            var lowerWordedMessage = message.ToLowerInvariant().ToWords()
                .ExceptKeyWords<T>().Except(WordsToSkip.Prepositions).ToList();
            if (lowerWordedMessage.Count == 0)
            {
                return NameNotSpecified;
            }
            var result = TextAnalysis.TextAnalysis.DefineMatchingEntity(
                lowerWordedMessage,
                WebJsonUtils.GetRecords<T>(
                    WebJsonUtils.DownloadJson<T>()
                ));

            if (result == null)
                return NotFound;

            var sb = new StringBuilder();

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