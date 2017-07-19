using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LvivOpenDataBots.Core.Data.Entities.Education;
using LvivOpenDataBots.Core.Infrastructure.Extensions;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Contract;
using static LvivOpenDataBots.Core.Infrastructure.TextAnalysis.TextAnalysis;
using static LvivOpenDataBots.Core.Infrastructure.TextAnalysis.WordsToSkip;
using static LvivOpenDataBots.Core.Infrastructure.Utils.Errors;
using static LvivOpenDataBots.Core.Infrastructure.Utils.WebJsonUtils;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Implementation
{
    public class EducationReplyBuilder<T> : IReplyBuilder<T>, IReplyBuilder where T : BaseEducationEntity
    {
        public async Task<string> BuildReplyAsync(List<string> intents, string message)
        {
            var lowerWordedMessage = message.ToLowerInvariant().ToWords()
                .ExceptKeyWords<T>().Except(Prepositions).ToList();
            if (lowerWordedMessage.Count is 0)
            {
                return NameNotSpecified;
            }
            var result = DefineMatchingEntity(
                lowerWordedMessage,
                GetRecords<T>(
                    DownloadJson<T>()
                ));

            if (result is null)
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