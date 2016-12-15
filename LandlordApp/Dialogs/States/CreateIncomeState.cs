using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;

namespace LandlordApp.Dialogs.States
{
    [Serializable]
    public class CreateIncomeState : ILandlordState
    {

        public static string ProvideIncomeMessage = "Please provide income in the following format frequency, amount e.g. monthly, 1600";
        public static string GreetingIncomeMessage = "Hi, How are you doing? What would you like to do?";
        public static string DontUnderstand = "I don't understand";

        private ILandlordState _nextState;

        private enum RentFrequency
        {
            Unknown,
            Monthly
        }

        public ILandlordState NextState
        {
            get
            {
                return _nextState;
            }
        }

        public CreateIncomeState()
        {
            _nextState = this;
        }

        public string CaptureExpense()
        {
            return DontUnderstand;
        }

        public string CaptureIncome()
        {
            return DontUnderstand;
        }

        public string Greeting()
        {
            return DontUnderstand;
        }

        public string None()
        {
            return DontUnderstand;
        }

        public string ShowStatement(IDialogContext context, LuisResult result)
        {
            return DontUnderstand;
        }

        public string None(IDialogContext context, LuisResult result)
        {

            string[] parts = result.Query.Split(',');
            if (parts.Length != 2)
            {
                return "You need to provide 2 pieces of information frequency and amount";
            }

            var frequencyText = parts[0];
            var amountText = parts[1];

            var frequency = RentFrequency.Unknown;

            switch (frequencyText)
            {
                case "monthly":
                    frequency = RentFrequency.Monthly;
                    break;
                default:
                    break;
            }

            if (frequency == RentFrequency.Unknown)
            {
                return "I don't understand the frequency \"" + frequencyText + "\". Please use either monthly or quartely";
            }

            decimal amount = 0;
            if (!decimal.TryParse(amountText, out amount))
            {
                return "Amount needs to be a number";
            }

            // create income

            _nextState = new InitialState();
            return "Income created successfully " + amount.ToString("£###,###,##0.00") + " (" + Enum.GetName(typeof(RentFrequency), frequency) + ")";

        }
    }
}