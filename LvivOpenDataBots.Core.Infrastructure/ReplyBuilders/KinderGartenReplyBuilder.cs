using System.Text;
using JetBrains.Annotations;
using LvivOpenDataBots.Core.Data.Entities.Education;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders
{
    public class KinderGartenReplyBuilder : IReplyBuilder<KinderGarten>
    {
        // please refactor this into StringWithDotNotNullBuilder
        public string BuildReply([NotNull] KinderGarten entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Ось що ми знайшли за цим запитом:");

            if (entity.Name != null)
            {
                sb.Append(entity.Name);
                sb.Append(", ");
            }

            if (entity.Street_name != null)
            {
                sb.Append(entity.Street_name);
                sb.Append(", ");
            }

            if (entity.Building_number != null)
            {
                if (entity.Building_number.EndsWith(@".0"))
                    entity.Building_number = entity.Building_number.Replace(".0","");
                sb.Append(entity.Building_number);
                sb.Append(", ");
            }

            if (entity.Name != null)
            {
                sb.Append(entity.Name);
                sb.Append(", ");
            }

            return sb.ToString();
        }
    }
}