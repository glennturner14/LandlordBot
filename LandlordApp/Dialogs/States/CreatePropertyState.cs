using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlordApp.Dialogs.States {
    [Serializable]
    public class CreatePropertyState : BaseState, ILandlordState {

        private ILandlordState _nextState;
        private bool _currentProperty; 



        public bool CurrentProperty {
            get {
                throw new NotImplementedException();
            }
        }

        public CreatePropertyState() {

            StatePrefix = "PS";

            _nextState = this;
            _currentProperty = false;
        }

        public string CaptureExpense() {
            _nextState = new CreateExpenseState();
            return GetStateMessage(CreateExpenseState.MESSAGE_PROVIDEEXPENSE);
        }

        public string CaptureIncome() {
            if (_currentProperty)
            _nextState = new CreateIncomeState();
            return GetStateMessage(CreateIncomeState.ProvideIncomeMessage);
        }

        public ILandlordState NextState {
            get { return this; }
        }

        public string Greeting() {
            return GetStateMessage(MESSAGE_GREETING);
        }

        public string None(IDialogContext message, LuisResult result) {
            throw new NotImplementedException();
        }

        public string ShowStatement(IDialogContext context, LuisResult result) {
            return GetStateMessage(MESSAGE_SHOWSTATEMENT);
        }
    }
}