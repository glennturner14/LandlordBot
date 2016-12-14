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

        private ILandlordState _nextState;

        public InitialState() {
            _nextState = this;
        }
        public string CaptureExpense() {
            _nextState = new CreateExpenseState();
            return "Capture Expense";
        }

        public string CaptureIncome() {
           return "Capture Income";
        }

        public ILandlordState NextState {
            get { return _nextState; }
        }

        public string Greeting() {
            return "Greeting";
        }

        public string None(IDialogContext context, LuisResult result) {
            return "I don't understand Initial state";
        }

        public string ShowStatement() {
            return "Show Statement";
        }
    }
}