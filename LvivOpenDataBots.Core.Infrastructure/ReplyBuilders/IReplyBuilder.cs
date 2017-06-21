using System.Collections.Generic;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders
{
    public interface IReplyBuilder
    {
        string BuildReply(List<string> intents, string message);

    }
}
