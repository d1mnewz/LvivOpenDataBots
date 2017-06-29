using System.Collections.Generic;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Contract
{
    public interface IReplyBuilder
    {
        string BuildReply(List<string> intents, string message);

    }
    public interface IReplyBuilder<T>
    {
    }
}
