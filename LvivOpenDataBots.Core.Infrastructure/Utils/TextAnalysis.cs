using System;
using System.Collections.Generic;
using System.Linq;
using com.valgut.libs.bots.Wit;
using JetBrains.Annotations;
using LvivOpenDataBots.Core.Data.Entities;
using LvivOpenDataBots.Core.Infrastructure.Extensions;
using Microsoft.Bot.Connector;

namespace LvivOpenDataBots.Core.Infrastructure.Utils
{
    public static class TextAnalysis
    {
        public static List<string> GetIntentsList(Activity activity, string aiKey)
        {
            var wit = new WitClient(aiKey);
            var msg = wit.Converse(activity.From.Id, activity.Text);

            try
            {
                return msg?.entities["intent"].Select(x => x.value.ToString()).ToList();
            }
            catch (KeyNotFoundException)
            {
                return new List<string>();
            }
        }

        [CanBeNull]
        public static T DefineMatchingEntity<T>(string message, IList<T> records) where T : BaseEntity // maybe i need some not-allowed keywords? like kindergarten that will be ignored
        {
            // remove key-words from message to parse
            var names = records.Select(x => x.Name);
            foreach (var name in names)
            {
                var splitedMessage = message.ToWords();
                foreach (var wordOfMessage in splitedMessage)
                {
                    var result = name.GetFirstMatchAndSourceBack(wordOfMessage, StringComparison.OrdinalIgnoreCase);
                    if (result.source != null && result.word != null)
                    {
                        return records.First(x => x.Name == result.source);
                    }
                }
            }
            return null;
        }
    }
}
