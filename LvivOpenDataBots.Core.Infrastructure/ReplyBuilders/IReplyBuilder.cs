namespace LvivOpenDataBots.Core.Infrastructure.ReplyBuilders
{
    public interface IReplyBuilder<in T>
    {
        string BuildReply(T entity);

    }
}
