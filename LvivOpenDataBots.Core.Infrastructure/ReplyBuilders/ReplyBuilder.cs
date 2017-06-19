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



            switch (typeof(T).Name)
            {
                case "KinderGarten":
                    KinderGarten kindergarten = entity as KinderGarten;

                    if (kindergarten.Name != null)
                    {
                        sb.Append(kindergarten.Name);
                        sb.Append(", ");
                    }
                    if (kindergarten.StreetName != null)
                    {
                        sb.Append(kindergarten.StreetName);
                        sb.Append(", ");
                    }

                    if (kindergarten.BuildingNumber != null)
                    {
                        if (kindergarten.BuildingNumber.EndsWith(@".0"))
                            kindergarten.BuildingNumber = kindergarten.BuildingNumber.Replace(".0", "");
                        sb.Append(kindergarten.BuildingNumber);
                        sb.Append(", ");
                    }

                    break;

                default: break;
            }

            return sb.ToString();
        }
    }
}
