using System.Collections.Generic;
using JetBrains.Annotations;
using LvivOpenDataBots.Core.Data.Entities.Education;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Contract;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Impelementations;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders
{
    public class ReplyBuilderFabric
    {
        [CanBeNull]
        public IReplyBuilder GetBuilder(List<string> intents)
        {
            if (intents.Count == 0)
                return null;
            if (intents.Contains("kindergarten"))
            {
                return new ReplyBuilder<KinderGarten>();
            }
            if (intents.Contains("gymnasium"))
            {
                return new ReplyBuilder<Gymnasium>();
            }
            if (intents.Contains("university"))
            {
                return new ReplyBuilder<University>();
            }
            if (intents.Contains("techlyceum"))
            {
                return new ReplyBuilder<TechLyceum>();
            }
            if (intents.Contains("preschool"))
            {
                return new ReplyBuilder<PreSchool>();
            }
            if (intents.Contains("school"))
            {
                return new ReplyBuilder<School>();
            }

            return null;

        }
    }
}
