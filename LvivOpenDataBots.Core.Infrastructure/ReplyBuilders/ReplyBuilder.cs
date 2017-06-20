using System.Collections.Generic;
using System.Linq;
using System.Text;
using LvivOpenDataBots.Core.Data.Entities.Education;
using static System.String;
using static LvivOpenDataBots.Core.Data.DataPacks.EducationDataPacksApiUrls;
using static LvivOpenDataBots.Core.Infrastructure.Utils;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders
{
    public class ReplyBuilder : IReplyBuilder
    {
        public string BuildReply(List<string> intents)
        {
            StringBuilder sb = new StringBuilder();
            var startReply = "Ось що ми знайшли за цим запитом:";
            sb.AppendLine(startReply);
            if (intents.Count > 0)
            {
                if (intents.Contains("kindergarten"))
                {
                    var records = GetRecords<KinderGarten>(DownloadJson<KinderGarten>());

                    var result = records.First(); // TODO: some analytics about how to define the entity we need


                    sb.Append($"{result.Name}");

                    if (intents.Contains("phone") && result.PhoneNumber != null)
                    {
                        sb.Append(", ");
                        sb.Append($"тел. {result.PhoneNumber}");
                    }
                    if (intents.Contains("address") && !IsNullOrWhiteSpace(result.StreetName) &&
                        !IsNullOrWhiteSpace(result.BuildingNumber))
                    {
                        sb.Append(", ");
                        sb.Append($"{result.StreetName}, {result.BuildingNumber}");

                    }
                }
                else if (intents.Contains("university"))
                {
                    return "TO BE IMPLEMENTED";
                }
                else if (intents.Contains("school"))
                {
                    return "TO BE IMPLEMENTED";
                }
                else if (intents.Contains("techlyceum"))
                {
                    return "TO BE IMPLEMENTED";
                }
                else if (intents.Contains("preschool"))
                {
                    return "TO BE IMPLEMENTED";
                }
                else if (intents.Contains("gymnasium"))
                {
                    return "TO BE IMPLEMENTED";
                }

            }

            return sb.ToString() == Concat(startReply, "\r\n") ? "Спробуйте сформувати своє питання по-іншому :)" : sb.ToString();

        }
    }
}
