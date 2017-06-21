using System.Collections.Generic;
using Microsoft.Bot.Connector;

namespace LvivOpenDataBots.Core.Infrastructure.Utils
{
    public static class BotFrameworkUtils
    {
        // Currently not used, but it should be useful when giving user a chance to define scope of data,
        // I have 'help' intent for that kind of things in wit.ai
        public static HeroCard CreateHeroCardForEducation()
        {
            return new HeroCard()
            {
                Title = "Які саме дані вам цікаві?",
                Subtitle = "Lviv Open Data",
                Images = new List<CardImage> {
                    new CardImage(url: "http://opendata.city-adm.lviv.ua/base/images/lviv.png")
                },
                Buttons = new List<CardAction> {
                    new CardAction()
                    {

                        Value = "Школи-садки",
                        Type = "imBack",
                        Title = "Школи-садки"
                    },
                    new CardAction()
                    {

                        Value = "Школи",
                        Type = "imBack",
                        Title = "Школи"
                    },
                    new CardAction()
                    {

                        Value = "Гімназії",
                        Type = "imBack",
                        Title = "Гімназії"
                    },
                    new CardAction()
                    {

                        Value = "Технікуми, ліцеї, училища",
                        Type = "imBack",
                        Title = "Технікуми, ліцеї, училища"
                    },
                    new CardAction()
                    {

                        Value = "Дошкільні навчальні заклади",
                        Type = "imBack",
                        Title = "Дошкільні навчальні заклади"
                    },
                    new CardAction()
                    {

                        Value = "Університети, академії, інститути",
                        Type = "imBack",
                        Title = "Університети, академії, інститути"
                    },
                }
            };
        }
    }

}

