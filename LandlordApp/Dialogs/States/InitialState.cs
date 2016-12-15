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
            return GetStateMessage(CreateIncomeState.MESSAGE_PROVIDEINCOME);
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

        public string ShowStatement() {
            return GetStateMessage(MESSAGE_SHOWSTATEMENT);
        }
    }
}