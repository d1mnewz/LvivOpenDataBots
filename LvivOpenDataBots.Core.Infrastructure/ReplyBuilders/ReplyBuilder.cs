using System.Collections.Generic;
using System.Linq;
using System.Text;
using LvivOpenDataBots.Core.Data.Entities.Education;
using static LvivOpenDataBots.Core.Data.DataPacks.EducationDataPacksApiUrls;
using static LvivOpenDataBots.Core.Infrastructure.Utils;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders
{
    public class ReplyBuilder : IReplyBuilder
    {
        public string BuildReply(List<string> intents)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Ось що ми знайшли за цим запитом:");

            if (intents.Contains("kindergarten"))
            {
                var records = GetRecords<KinderGarten>(DownloadJson(KinderGartens));

                // some analytics about how to define the entity we need
                var result = records.First(); // TODO


                sb.Append($"{result.Name}");

                if (intents.Contains("phone"))
                {
                    sb.Append(", ");
                    sb.Append($"тел. {result.PhoneNumber}");
                }
            }

            else if (intents.Contains("university"))
            {
                return "univ";
            }

            return sb.ToString();
        }
    }
}
