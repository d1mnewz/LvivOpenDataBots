using System.Collections.Generic;
using JetBrains.Annotations;
using LvivOpenDataBots.Core.Data.Entities.Education;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Contract;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Implementation;

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
                return new EducationReplyBuilder<KinderGarten>();
            }
            if (intents.Contains("gymnasium"))
            {
                return new EducationReplyBuilder<Gymnasium>();
            }
            if (intents.Contains("university"))
            {
                return new EducationReplyBuilder<University>();
            }
            if (intents.Contains("techlyceum"))
            {
                return new EducationReplyBuilder<TechLyceum>();
            }
            if (intents.Contains("preschool"))
            {
                return new EducationReplyBuilder<PreSchool>();
            }
            if (intents.Contains("school"))
            {
                return new EducationReplyBuilder<School>();
            }

            return null;

        }
    }
}
