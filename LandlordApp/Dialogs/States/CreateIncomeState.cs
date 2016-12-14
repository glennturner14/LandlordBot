using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;

namespace LandlordApp.Dialogs.States {
    [Serializable]
    public class CreateIncomeState : ILandlordState {

        public static string ProvideIncomeMessage = "Please provide income in the following format {freq},{Amount #.##}";
        public static string GreetingIncomeMessage = "Hi, How are you doing? What would you like to do?";
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
            return GreetingIncomeMessage;
        }

        public string None() {
            return DontUnderstand;
        }

        public string ShowStatement() {
            throw new NotImplementedException();
        }

        public string None(IDialogContext context, LuisResult result) {
            throw new NotImplementedException();
        }
    }
}