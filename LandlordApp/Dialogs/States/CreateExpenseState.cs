using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlordApp.Dialogs.States {
    [Serializable]
    public class CreateExpenseState : ILandlordState {
        public ILandlordState NextState {
            get {
                return this;
            }
        }

        public string CaptureExpense() {
            throw new NotImplementedException();
        }

        public string CaptureIncome() {
            throw new NotImplementedException();
        }

        public string Greeting() {
            throw new NotImplementedException();
        }

        public string None(IDialogContext context, LuisResult result) {

            var replyToConversation = context.MakeMessage();
            //replyToConversation.Recipient = context.From;
            replyToConversation.Type = "message";
            replyToConversation.Attachments = new List<Attachment>();
            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: "https://s-media-cache-ak0.pinimg.com/564x/39/03/b3/3903b3b596f8e4519c055ad5ca96a5a6.jpg"));
            //cardImages.Add(new CardImage(url: "https://<ImageUrl2>"));
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction()
            {
                Value = "https://en.wikipedia.org/wiki/Pig_Latin",
                Type = "openUrl",
                Title = "WikiPedia Page"
            };
            cardButtons.Add(plButton);
            HeroCard plCard = new HeroCard()
            {
                Title = "I'm a hero card",
                Subtitle = "Pig Latin Wikipedia Page",
                Images = cardImages,
                Buttons = cardButtons
            };
            Attachment plAttachment = plCard.ToAttachment();
            replyToConversation.Attachments.Add(plAttachment);
            var reply = context.PostAsync(replyToConversation);

            return "I don't understand expense";

        }

        public string ShowStatement() {
            throw new NotImplementedException();
        }
    }
}