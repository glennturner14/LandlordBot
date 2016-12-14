using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlordApp.Dialogs.States {
    [Serializable]
    public class CreateExpenseState : ILandlordState {
        public ILandlordState NextState {
            get {
                return this;
            }
        }

        public string CaptureExpense() {
            throw new NotImplementedException();
        }

        public string CaptureIncome() {
            throw new NotImplementedException();
        }

        public string Greeting() {
            throw new NotImplementedException();
        }

        public string None() {
            return "I don't understand Create Expense state";
        }

        public string ShowStatement() {
            throw new NotImplementedException();
        }
    }
}