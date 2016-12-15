using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlordApp.Dialogs.States {
    [Serializable]
    public class CreateExpenseState : BaseState, ILandlordState {

        public static string MESSAGE_PROVIDEEXPENSE = "Please provide expense in the following format {dd / mm / yyyy},{Amount #.##}";

        private ILandlordState _nextState;

        public CreateExpenseState() {
            base.StatePrefix = "ES";

            _nextState = this;

        }

        public bool CurrentProperty {
            get {
                throw new NotImplementedException();
            }
        }

        public ILandlordState NextState {
            get {
                return this;
            }
        }

        public string CaptureExpense() {
            return this.GetStateMessage(CreateExpenseState.MESSAGE_PROVIDEEXPENSE);
        }

        public string CaptureIncome() {
            _nextState = new CreateIncomeState();
            return GetStateMessage(CreateIncomeState.MESSAGE_PROVIDEINCOME);
        }

        public string Greeting() {
            return GetStateMessage(MESSAGE_GREETING);
        }

        public string None(IDialogContext context, LuisResult result) {

            switch (result.Query)
            {

                case "test1":
                    return CreateHeroCard(context, result);

                case "test2":
                    return CreateThumbnail(context, result);

                case "test3":
                    var descriptions = new List<string>();
                    var amounts = new List<decimal>();
                    for (int i = 0; i < 12; i++)
                    {
                        descriptions.Add(new DateTime(2016, i + 1, 21).ToShortDateString() + " -  Rent");
                        amounts.Add(1200);
                    }
                    return CreateReceipt(context, result, "Account Statement to date", descriptions.ToArray(), amounts.ToArray(), 1000m);

                default:
                    return "none";
            }
            
        }

        private string CreateReceipt(IDialogContext context, LuisResult result, string title, string[] descriptions, decimal[] prices, decimal tax)
        {
            var replyToConversation = context.MakeMessage();
            replyToConversation.Type = "message";
            replyToConversation.Attachments = new List<Attachment>();
            List<CardImage> cardImages = new List<CardImage>();
            //cardImages.Add(new CardImage(url: "https://static-s.aa-cdn.net/img/gp/20600004700445/H8HgqumAcQ6CV3VqjlqUNfatF5xzrgcETIApZy5vTu_y8zGATBeZ-KhaAW_rh9Vuzg=w300?v=1"));
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction()
            {
                Value = "https://en.wikipedia.org/wiki/Pig_Latin",
                Type = "openUrl",
                Title = "WikiPedia Page"
            };
            cardButtons.Add(plButton);

            List<ReceiptItem> receiptList = new List<ReceiptItem>();

            for (int i = 0; i < descriptions.Length; i++)
            {
                ReceiptItem lineItem1 = new ReceiptItem()
                {
                    Title = descriptions[i],
                    Subtitle = "8 lbs",
                    Text = null,
                    Price = prices[i].ToString("#,###,##0.00"),
                    Quantity = "1",
                    Tap = null
                };
                receiptList.Add(lineItem1);
            }
            
            ReceiptCard plCard = new ReceiptCard()
            {
                Title = title,
                Buttons = cardButtons,
                Items = receiptList,
                Total = (prices.Sum() + tax).ToString("#,###,##0.00"),
                Tax = tax.ToString("#,###,##0.00")
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
            
            replyToConversation.Attachments.Add(CreateThumbnailAttachment());
            replyToConversation.Attachments.Add(CreateThumbnailAttachment());

            replyToConversation.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            context.PostAsync(replyToConversation); ;

            return "thumbnail";

        }

        private Attachment CreateThumbnailAttachment() {

            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: "https://s-media-cache-ak0.pinimg.com/564x/39/03/b3/3903b3b596f8e4519c055ad5ca96a5a6.jpg"));
            List<CardAction> cardButtons = new List<CardAction>();

            ThumbnailCard plCard = new ThumbnailCard()
            {
                Title = "I'm a thumbnail card",
                Subtitle = "Pig Latin Wikipedia Page",
                Images = cardImages,
                Buttons = cardButtons
            };
            Attachment plAttachment = plCard.ToAttachment();

            return plAttachment;

        }

        private string CreateHeroCard(IDialogContext context, LuisResult result)
        {
            var replyToConversation = context.MakeMessage();
            //replyToConversation.Recipient = context.From;
            replyToConversation.Type = "message";
            replyToConversation.Attachments = new List<Attachment>();
            
            replyToConversation.Attachments.Add(CreateHeroCardAttachment());
            replyToConversation.Attachments.Add(CreateHeroCardAttachment());

            replyToConversation.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            
            context.PostAsync(replyToConversation);

            return "I don't understand expense";

        }

        private Attachment CreateHeroCardAttachment() {

            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: "https://s-media-cache-ak0.pinimg.com/564x/39/03/b3/3903b3b596f8e4519c055ad5ca96a5a6.jpg"));
            List<CardAction> cardButtons = new List<CardAction>();

            HeroCard plCard = new HeroCard()
            {
                Title = "I'm a hero card",
                Subtitle = "Pig Latin Wikipedia Page",
                Images = cardImages,
                Buttons = cardButtons,
                Text = "blah blah blah"
            };
            Attachment plAttachment = plCard.ToAttachment();

            return GetStateMessage(DontUnderstand);

        }

        public string ShowStatement() {
            return GetStateMessage(MESSAGE_SHOWSTATEMENT);
        }
    }
}