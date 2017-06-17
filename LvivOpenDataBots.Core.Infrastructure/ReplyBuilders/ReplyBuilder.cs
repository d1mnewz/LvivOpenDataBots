using System.Text;
using JetBrains.Annotations;
using LvivOpenDataBots.Core.Data.Entities;
using LvivOpenDataBots.Core.Data.Entities.Education;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders
{
    public class ReplyBuilder<T> where T : BaseEntity
    {
        public string BuildReply([NotNull] T entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Ось що ми знайшли за цим запитом:");

            if (entity.Name != null)
            {
                sb.Append(entity.Name);
                sb.Append(", ");
            }

            // insert here new models
            switch (typeof(T).ToString())
            {
                case "Kindergarten":
                    KinderGarten kindergarten = entity as KinderGarten;

                    if (kindergarten.Street_name != null)
                    {
                        sb.Append(kindergarten.Street_name);
                        sb.Append(", ");
                    }

                    if (kindergarten.Building_number != null)
                    {
                        if (kindergarten.Building_number.EndsWith(@".0"))
                            kindergarten.Building_number = kindergarten.Building_number.Replace(".0", "");
                        sb.Append(kindergarten.Building_number);
                        sb.Append(", ");
                    }

                    break;

                default: break;
            }

            return sb.ToString();
        }
    }
}
