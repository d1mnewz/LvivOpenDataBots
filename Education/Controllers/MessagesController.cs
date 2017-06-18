using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LvivOpenDataBots.Core.Data.Entities.Education;
using LvivOpenDataBots.Core.Infrastructure.ReplyBuilders;
using Microsoft.Bot.Connector;
using static LvivOpenDataBots.Core.Data.DataPacks.EducationDataPacksApiUrls;
using static LvivOpenDataBots.Core.Infrastructure.Utils;

namespace Education.Controllers
{
    //   [BotAuthentication]
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
                var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                var rb = new ReplyBuilder<KinderGarten>();

                string replyText = rb.BuildReply(
                    GetRecords<KinderGarten>(DownloadJson(KinderGartens)).First());
                Activity reply = activity.CreateReply(replyText);
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}