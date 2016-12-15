using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlordApp.Dialogs.States {
    [Serializable]
    public class InitialState : ILandlordState {

        private string StatePrefix = "IS";

        private ILandlordState _nextState;

        public static string MESSAGE_GREETINGS = "Hi, How are you doing? What would you like to do?";
        public static string MESSAGE_DONTUNDERSTAND = "I don't understand";
        public static string MESSAGE_SHOWSTATEMENT = "Here's your current statement";

        public InitialState() {
            _nextState = this;
        }
        public string CaptureExpense() {
            _nextState = new CreateExpenseState();
            return GetStateMessage(CreateExpenseState.ProvideExpenseMessage);
         }

        public string CaptureIncome() {
            _nextState = new CreateIncomeState();
            return GetStateMessage(CreateIncomeState.ProvideIncomeMessage);
        }

        public ILandlordState NextState {
            get { return _nextState; }
        }

        public string Greeting() {
            return GetStateMessage(MESSAGE_GREETINGS);
        }

        public string None(IDialogContext context, LuisResult result) {
            return GetStateMessage(MESSAGE_DONTUNDERSTAND);
        }

        public string ShowStatement(IDialogContext context, LuisResult result) {
            var descriptions = new List<string>();
            var amounts = new List<decimal>();
            for (int i = 0; i < 12; i++)
            {
                descriptions.Add(new DateTime(2016, i + 1, 21).ToShortDateString() + " -  Rent");
                amounts.Add(1200);
            }
            CreateReceipt(context, result, "Account Statement to date", descriptions.ToArray(), amounts.ToArray(), 1000m);
            return GetStateMessage(MESSAGE_SHOWSTATEMENT);
        }

        private string GetStateMessage(string msg) {
            return string.Format("{0}-{1}", StatePrefix, msg);
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

    }
}