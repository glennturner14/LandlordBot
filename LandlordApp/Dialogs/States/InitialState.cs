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

        public string ShowStatement() {
            return GetStateMessage(MESSAGE_SHOWSTATEMENT);
        }

        private string GetStateMessage(string msg) {
            return string.Format("{0}-{1}", StatePrefix, msg);
        }
    }
}