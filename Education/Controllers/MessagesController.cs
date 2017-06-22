using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders;
using Microsoft.Bot.Connector;
using static LvivOpenDataBots.Core.Infrastructure.TextAnalysis.TextAnalysis;

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
                var intents = GetIntentsList(activity: activity, aiKey: WebConfigurationManager.AppSettings["AiKey"]);
                var replyText = "На жаль, ми нічого не знайшли за цим запитом :(";
                Activity reply = activity.CreateReply(text: replyText);

                #region HelpHeroCard
                //if (intents.Contains("help")) // how to implement scoping without local storage?
                //{
                //    reply.Attachments = new List<Attachment> {
                //        Utils.CreateHeroCardForEducation().ToAttachment()
                //    };
                //}
                //else
                //{
                #endregion

                if (intents.Count > 0)
                {
                    var rbFabric = new ReplyBuilderFabric();

                    replyText = rbFabric.GetBuilder(intents).BuildReply(intents: intents, message: activity.Text);
                    reply = activity.CreateReply(text: replyText);
                }
                await connector.Conversations.ReplyToActivityAsync(activity: reply);
            }
            var response = Request.CreateResponse(statusCode: HttpStatusCode.OK);
            return response;
        }
    }
}