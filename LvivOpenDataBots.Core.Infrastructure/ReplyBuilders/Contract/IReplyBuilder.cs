using System.Collections.Generic;
using System.Threading.Tasks;

namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders.Contract
{
    public interface IReplyBuilder
    {
        Task<string> BuildReplyAsync(List<string> intents, string message);

    }
    public interface IReplyBuilder<T>
    {
    }
}
