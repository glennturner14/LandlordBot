﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlordApp.Dialogs.States {
    [Serializable]
    public class CreateExpenseState : ILandlordState {

        private string StatePrefix = "ES";

        public static string ProvideExpenseMessage = "Please provide expense in the following format {dd / mm / yyyy},{Amount #.##}";
        public static string GreetingExpenseMessage = "Hi, How are you doing? What would you like to do?";
        public static string DontUnderstand = "I don't understand";
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
            return GetStateMessage(GreetingExpenseMessage);
        }

        public string None() {
            return GetStateMessage(DontUnderstand);
        }

        public string ShowStatement() {
            throw new NotImplementedException();
        }

        private string GetStateMessage(string msg) {
            return string.Format("{0}-{1}", StatePrefix, msg);
        }
    }
}