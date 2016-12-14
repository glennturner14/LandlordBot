using LandlordApp.Dialogs.States;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LandlordApp.Dialogs {

    [Serializable]
    [LuisModel("fbd5a850-4d2c-404e-abf6-c6688d0bf7e2", "41421c8e26fd4a90a025d3afbf31831c")]
    public class LandlordDialog : LuisDialog<object> {

        private ILandlordState _currentState;

        public ILandlordState CurrentState {
            get {
                if (_currentState == null) {
                    _currentState = new InitialState();
                }

                return _currentState; }

            set { _currentState = value; }
        }

        /// <summary>
        /// Deal with anything unknown
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result) {
            string message = CurrentState.None(context, result);
            await SendReply(context, message);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result) {
            string message = CurrentState.Greeting();
            await SendReply(context, message);
        }

        [LuisIntent("CaptureIncome")]
        public async Task CaptureIncome(IDialogContext context, LuisResult result) {
            string message = CurrentState.CaptureIncome();
            await SendReply(context, message);
        }

        [LuisIntent("CaptureExpense")]
        public async Task CaptureExpense(IDialogContext context, LuisResult result) {
            string message = CurrentState.CaptureExpense();
            await SendReply(context, message);
        }

        [LuisIntent("ShowStatement")]
        public async Task ShowStatement(IDialogContext context, LuisResult result) {
            string message = CurrentState.ShowStatement();
            await SendReply(context, message);
        }

        private async Task SendReply(IDialogContext context, string message) {
            await context.PostAsync(message);
            context.Wait(MessageReceived);
            CurrentState = CurrentState.NextState;
        }
    }
}