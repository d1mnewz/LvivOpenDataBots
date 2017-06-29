using System.Collections.Generic;
using System.Linq;
using System.Text;
using LvivOpenDataBots.Core.Data.Entities.Education;
using LvivOpenDataBots.Core.Infrastructure.Extensions;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Contract;
using LvivOpenDataBots.Core.Infrastructure.TextAnalysis;
using LvivOpenDataBots.Core.Infrastructure.Utils;
using static LvivOpenDataBots.Core.Infrastructure.Utils.Errors;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Impelementation
{
    public class EducationReplyBuilder<T> : IReplyBuilder<T>, IReplyBuilder where T : BaseEducationEntity
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
                if (result.Address != null)
                    sb.Append($"{result.Name}, {result.Address}");
                else return NoAddress;

            }
            else if (intents.Contains("phone"))
            {
                if (result.PhoneNumber != null)
                    sb.Append($"{result.Name}, {result.PhoneNumber}");
                else return NoPhoneNumber;
            }
            return sb.ToString();
        }
    }
}