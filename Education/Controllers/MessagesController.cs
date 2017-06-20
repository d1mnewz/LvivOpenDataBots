using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LvivOpenDataBots.Core.Infrastructure;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders;
using Microsoft.Bot.Connector;

namespace Education.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                var connector = new ConnectorClient(new Uri(uriString: activity.ServiceUrl));
                var rb = new ReplyBuilder();

                string replyText = rb.BuildReply(Utils.GetIntentsList(activity));

                Activity reply = activity.CreateReply(text: replyText);
                await connector.Conversations.ReplyToActivityAsync(activity: reply);
            }
            var response = Request.CreateResponse(statusCode: HttpStatusCode.OK);
            return response;
        }
    }
}