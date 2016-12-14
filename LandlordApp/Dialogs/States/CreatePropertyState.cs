using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlordApp.Dialogs.States {
    [Serializable]
    public class CreatePropertyState : ILandlordState {
        public string CaptureExpense() {
            throw new NotImplementedException();
        }

        public string CaptureIncome() {
            throw new NotImplementedException();
        }

        public ILandlordState NextState {
            get { return this; }
        }

        public string Greeting() {
            throw new NotImplementedException();
        }

        public string None(IDialogContext message, LuisResult result) {
            throw new NotImplementedException();
        }

        public string ShowStatement() {
            throw new NotImplementedException();
        }
    }
}