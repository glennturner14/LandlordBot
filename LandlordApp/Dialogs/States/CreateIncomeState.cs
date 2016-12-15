using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;

namespace LandlordApp.Dialogs.States {
    [Serializable]
    public class CreateIncomeState : BaseState, ILandlordState {

        public static string MESSAGE_PROVIDEINCOME = "Please provide income in the following format {freq},{Amount #.##}";

        private ILandlordState _nextState;

        public CreateIncomeState() {

            StatePrefix = "INCS";

        }

        public ILandlordState NextState {
            get {
                return this;
            }
        }

        public string CaptureExpense() {
            _nextState = new CreateExpenseState();
            return GetStateMessage(CreateExpenseState.MESSAGE_PROVIDEEXPENSE);
        }

        public string CaptureIncome() {
            return GetStateMessage(MESSAGE_PROVIDEINCOME);
        }

        public string Greeting() {
            return GetStateMessage(MESSAGE_GREETING);
        }

        public string None() {
            return GetStateMessage(MESSAGE_DONTUNDERSTAND);
        }

        public string ShowStatement() {
            return GetStateMessage(MESSAGE_SHOWSTATEMENT);
        }

        public string None(IDialogContext context, LuisResult result) {
            throw new NotImplementedException();
        }

        public bool CurrentProperty {
            get {
                throw new NotImplementedException();
            }
        }
    }
}