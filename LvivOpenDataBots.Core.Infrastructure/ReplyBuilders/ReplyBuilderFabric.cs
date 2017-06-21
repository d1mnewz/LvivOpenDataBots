using System.Collections.Generic;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Impelementations;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders
{
    public class ReplyBuilderFabric
    {
        public IReplyBuilder GetBuilder(List<string> intents, string message)
        {
            if (intents.Count <= 0)
                return null;

            if (intents.Contains("kindergarten"))
            {
                return new KinderGartenReplyBuilder();
            }
            if (intents.Contains("university"))
            {
                return new UniversityReplyBuilder();
            }
            if (intents.Contains("school"))
            {
                return new SchoolReplyBuilder();
            }
            if (intents.Contains("techlyceum"))
            {
                return new TechLyceumReplyBuilder();
            }
            if (intents.Contains("preschool"))
            {
                return new PreSchoolReplyBuilder();
            }
            if (intents.Contains("gymnasium"))
            {
                return new GymnasiumReplyBuilder();
            }
            return null;

        }
    }
}
