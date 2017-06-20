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
            var startReply = "Ось що ми знайшли за цим запитом:";
            sb.AppendLine(startReply);
            if (intents.Count > 0)
            {
                if (intents.Contains("kindergarten"))
                {
                    var records = GetRecords<KinderGarten>(DownloadJson(KinderGartens));

                    var result = records.First(); // TODO: some analytics about how to define the entity we need


                    sb.Append($"{result.Name}");

                    if (intents.Contains("phone"))
                    {
                        sb.Append(", ");
                        sb.Append($"тел. {result.PhoneNumber}");
                    }
                    if (intents.Contains("address"))
                    {
                        sb.Append(", ");
                        sb.Append($"{result.StreetName}, {result.BuildingNumber}");
                    }
                }

                else if (intents.Contains("university"))
                {
                    return "TO BE IMPLEMENTED";
                }
            }
            var res = sb.ToString();
            var res2 = sb.ToString().Equals(startReply);
            var res3 = sb.ToString() == startReply;
            var fu = string.Concat(startReply, "\r\n");
            if (sb.ToString() == fu)
                return "Спробуйте сформувати своє питання по-іншому :)";
            else return sb.ToString();

        }
    }
}
