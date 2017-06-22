using System.Collections.Generic;
using JetBrains.Annotations;
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
                return new KinderGartenReplyBuilder();
            }
            if (intents.Contains("gymnasium"))
            {
                return new GymnasiumReplyBuilder();
            }
            if (intents.Contains("university"))
            {
                return new UniversityReplyBuilder();
            }
            if (intents.Contains("techlyceum"))
            {
                return new TechLyceumReplyBuilder();
            }
            if (intents.Contains("preschool"))
            {
                return new PreSchoolReplyBuilder();
            }
            if (intents.Contains("school"))
            {
                return new SchoolReplyBuilder();
            }

            return null;

        }
    }
}
