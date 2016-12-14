using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LandlordApp.Dialogs {

    [Serializable]
    [LuisModel("fbd5a850-4d2c-404e-abf6-c6688d0bf7e2", "41421c8e26fd4a90a025d3afbf31831c")]
    public class LandlordDialog : LuisDialog<object> {
        /// <summary>
        /// Deal with anything unknown
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result) {
            string message = "I don't understand";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result) {
            string message = "Greeting";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("CaptureIncome")]
        public async Task CaptureIncome(IDialogContext context, LuisResult result) {
            string message = "Capture Income";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("CaptureExpense")]
        public async Task CaptureExpense(IDialogContext context, LuisResult result) {
            string message = "Capture Expense";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("ShowStatement")]
        public async Task ShowStatement(IDialogContext context, LuisResult result) {
            string message = "Show Statement";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
    }
}