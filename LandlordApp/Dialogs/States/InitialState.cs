using LandlordApp.DomainModel.Entities;
using LandlordApp.Repositories;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlordApp.Dialogs.States {
    [Serializable]
    public class InitialState : BaseState, ILandlordState {

        private ILandlordState _nextState;

        public InitialState() {

            StatePrefix = "IS";

            _nextState = this;
        }
        public string CaptureExpense() {
            _nextState = new CreateExpenseState();
            return this.GetStateMessage(CreateExpenseState.MESSAGE_PROVIDEEXPENSE);
         }

        public string CaptureIncome() {
            _nextState = new CreateIncomeState();
            return GetStateMessage(CreateIncomeState.ProvideIncomeMessage);
        }

        public ILandlordState NextState {
            get { return _nextState; }
        }

        public bool CurrentProperty {
            get {
                throw new NotImplementedException();
            }
        }

        public string Greeting() {
            return GetStateMessage(MESSAGE_GREETING);
        }

        public string None(IDialogContext context, LuisResult result) {
            return GetStateMessage(MESSAGE_DONTUNDERSTAND);
        }

        public string ShowStatement(IDialogContext context, LuisResult result) {
            //var descriptions = new List<string>();
            //var amounts = new List<decimal>();
            //for (int i = 0; i < 12; i++)
            //{
            //    descriptions.Add(new DateTime(2016, i + 1, 21).ToShortDateString() + " -  Rent");
            //    amounts.Add(1200);
            //}
            //CreateReceipt(context, result, "Account Statement to date", descriptions.ToArray(), amounts.ToArray(), 1000m);

            StatementGateway statementGateway = new StatementGateway();
            List<StatementLine> statementLines = statementGateway.GetStatementLines();

            CreateStatement(context, result, "Account Statement to date", statementLines);

            return GetStateMessage(MESSAGE_SHOWSTATEMENT);
        }



        private string CreateStatement(IDialogContext context, LuisResult result, string title, List<StatementLine> statementLines) {
            var replyToConversation = context.MakeMessage();
            replyToConversation.Type = "message";
            replyToConversation.Attachments = new List<Attachment>();
            List<CardImage> cardImages = new List<CardImage>();
            //cardImages.Add(new CardImage(url: "https://static-s.aa-cdn.net/img/gp/20600004700445/H8HgqumAcQ6CV3VqjlqUNfatF5xzrgcETIApZy5vTu_y8zGATBeZ-KhaAW_rh9Vuzg=w300?v=1"));
            List<CardAction> cardButtons = new List<CardAction>();
            CardAction plButton = new CardAction() {
                Value = "https://en.wikipedia.org/wiki/Pig_Latin",
                Type = "openUrl",
                Title = "WikiPedia Page"
            };
            cardButtons.Add(plButton);

            List<ReceiptItem> receiptList = new List<ReceiptItem>();

            foreach (StatementLine statementLine in statementLines) {
                ReceiptItem lineItem1 = new ReceiptItem() {
                    Title = string.Format("{0} - {1}", statementLine.Date, (string.IsNullOrEmpty(statementLine.Description) ? "Rent" : statementLine.Description)),
                    Subtitle = "8 lbs",
                    Text = null,
                    Price = statementLine.Amount.ToString("#,##0.00;(#,##0.00)"),
                    Quantity = "1",
                    Tap = null
                };
                receiptList.Add(lineItem1);
            }



            ReceiptCard plCard = new ReceiptCard() {
                Title = title,
                Buttons = cardButtons,
                Items = receiptList,
                Total = statementLines.Sum(x => x.Amount).ToString("#,###,##0.00")
            };
            Attachment plAttachment = plCard.ToAttachment();
            replyToConversation.Attachments.Add(plAttachment);
            context.PostAsync(replyToConversation);

            return "create receipt";
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

        public string CreateProperty(IDialogContext context, LuisResult result)
        {

            var properties = new List<Property>();
            properties.Add(new Property() {
                PropertyId = 1,
                Address = new DomainModel.Entities.Address() {
                    AddressLine1 = "125 London Road",
                    Town = "Kingston upon Thames",
                    County  ="Surrey",
                    Country =  "UK",
                    PostCode = "KT2 6SR"
                },
                Type = PropertyType.UKProperty
            });

            properties.Add(new Property()
            {
                PropertyId = 1,
                Address = new DomainModel.Entities.Address()
                {
                    AddressLine1 = "1 Brighton Road",
                    Town = "Brighton",
                    County = "West Sussex",
                    Country = "UK",
                    PostCode = "BR1 3PU"
                },
                Type = PropertyType.UKFurnishedHolidayLet
            });

            properties.Add(new Property()
            {
                PropertyId = 1,
                Address = new DomainModel.Entities.Address()
                {
                    AddressLine1 = "1 Jean Claude Route",
                    Town = "Nante",
                    County = "???",
                    Country = "France",
                },
                Type = PropertyType.EEAFurnishedHolidayLet
            });

            var replyToConversation = context.MakeMessage();
            replyToConversation.Type = "message";
            replyToConversation.Attachments = new List<Attachment>();

            foreach (var property in properties)
            {
                replyToConversation.Attachments.Add(CreateThumbnailAttachment(property));
            }
            
            replyToConversation.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            context.PostAsync(replyToConversation);


            _nextState = new InitialState();
            return "Create property";
        }

        private Attachment CreateThumbnailAttachment(Property property)
        {

            string imageUrl = "http://www.emoji.co.uk/files/apple-emojis/travel-places-ios/573-house-building.png";
            switch (property.Type)
            {
                case PropertyType.UKProperty:
                    imageUrl = "http://www.emoji.co.uk/files/apple-emojis/travel-places-ios/573-house-building.png";
                    break;
                case PropertyType.UKFurnishedHolidayLet:
                    imageUrl = "https://www.midoro.me/wp-content/uploads/2014/01/House-for-Holiday-128x128.png";
                    break;
                case PropertyType.EEAFurnishedHolidayLet:
                    imageUrl = "https://www.timeshighereducation.com/sites/default/files/styles/the_breaking_news_image_style/public/european-union-eu-flag-missing-star-brexit.jpg?itok=BByEG7EK";
                    break;
            }

            List<CardImage> cardImages = new List<CardImage>();
            cardImages.Add(new CardImage(url: imageUrl));
            List<CardAction> cardButtons = new List<CardAction>();

            ThumbnailCard plCard = new ThumbnailCard()
            {
                Title = property.Address.AddressLine1,
                Subtitle = Enum.GetName(typeof(PropertyType), property.Type),
                Images = cardImages,
                Buttons = cardButtons,
                Text = 
                property.Address.AddressLine1
                + "\r\n" + property.Address.County
                + "\r\n" + property.Address.Country
            };
            Attachment plAttachment = plCard.ToAttachment();

            return plAttachment;

        }
    }
}