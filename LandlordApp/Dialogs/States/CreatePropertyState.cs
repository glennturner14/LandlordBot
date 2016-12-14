using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlordApp.Dialogs.States {
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

        public string None() {
            throw new NotImplementedException();
        }

        public string ShowStatement() {
            throw new NotImplementedException();
        }
    }
}