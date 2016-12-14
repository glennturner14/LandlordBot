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

        private string StatePrefix = "ES";

        public static string ProvideExpenseMessage = "Please provide expense in the following format {dd / mm / yyyy},{Amount #.##}";
        public static string GreetingExpenseMessage = "Hi, How are you doing? What would you like to do?";
        public static string DontUnderstand = "I don't understand";
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
            return GetStateMessage(GreetingExpenseMessage);
        }

        public string None(IDialogContext context, LuisResult result) {

            switch (result.Query)
            {

                case "test1":
                    return CreateHeroCard(context, result);

                case "test2":
                    return CreateThumbnail(context, result);

                case "test3":
                    return CreateReceipt(context, result);

                default:
                    return "none";
            }
            
        }

        private string CreateReceipt(IDialogContext context, LuisResult result)
        {
            var replyToConversation = context.MakeMessage();
            //replyToConversation.Recipient = message.From;
            replyToConversation.Type = "message";
            replyToConversation.Attachments = new List<Attachment>();
            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: "https://static-s.aa-cdn.net/img/gp/20600004700445/H8HgqumAcQ6CV3VqjlqUNfatF5xzrgcETIApZy5vTu_y8zGATBeZ-KhaAW_rh9Vuzg=w300?v=1"));
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction()
            {
                Value = "https://en.wikipedia.org/wiki/Pig_Latin",
                Type = "openUrl",
                Title = "WikiPedia Page"
            };
            cardButtons.Add(plButton);
            ReceiptItem lineItem1 = new ReceiptItem()
            {
                Title = "Pork Shoulder",
                Subtitle = "8 lbs",
                Text = null,
                Image = new CardImage(url: "http://www.terrafloraonline.com/images/userfiles/images/flower01LOW.png"),
                Price = "16.25",
                Quantity = "1",
                Tap = null
            };
            ReceiptItem lineItem2 = new ReceiptItem()
            {
                Title = "Bacon",
                Subtitle = "5 lbs",
                Text = null,
                Image = new CardImage(url: "http://www.iconarchive.com/icons/fasticon/nature/256/Blue-Flower-icon.png"),
                Price = "34.50",
                Quantity = "2",
                Tap = null
            };
            List<ReceiptItem> receiptList = new List<ReceiptItem>();
            receiptList.Add(lineItem1);
            receiptList.Add(lineItem2);
            ReceiptCard plCard = new ReceiptCard()
            {
                Title = "I'm a receipt card, isn't this bacon expensive?",
                Buttons = cardButtons,
                Items = receiptList,
                Total = "275.25",
                Tax = "27.52"
            };
            Attachment plAttachment = plCard.ToAttachment();
            replyToConversation.Attachments.Add(plAttachment);
            context.PostAsync(replyToConversation);

            return "create receipt";
        }

        private string CreateThumbnail(IDialogContext context, LuisResult result)
        {
            var replyToConversation = context.MakeMessage();
            //replyToConversation.Recipient = message.From;
            replyToConversation.Type = "message";
            replyToConversation.Attachments = new List<Attachment>();
            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: "https://s-media-cache-ak0.pinimg.com/564x/39/03/b3/3903b3b596f8e4519c055ad5ca96a5a6.jpg"));
            List <CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction()
            {
                Value = "https://en.wikipedia.org/wiki/Pig_Latin",
                Type = "openUrl",
                Title = "WikiPedia Page"
            };
            cardButtons.Add(plButton);
            ThumbnailCard plCard = new ThumbnailCard()
            {
                Title = "I'm a thumbnail card",
                Subtitle = "Pig Latin Wikipedia Page",
                Images = cardImages,
                Buttons = cardButtons
            };
            Attachment plAttachment = plCard.ToAttachment();
            replyToConversation.Attachments.Add(plAttachment);
            context.PostAsync(replyToConversation); ;

            return "thumbnail";

        }

        private string CreateHeroCard(IDialogContext context, LuisResult result)
        {
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
            context.PostAsync(replyToConversation);

            return "I don't understand expense";

        }

        public string ShowStatement() {
            throw new NotImplementedException();
        }

        private string GetStateMessage(string msg) {
            return string.Format("{0}-{1}", StatePrefix, msg);
        }
    }
}