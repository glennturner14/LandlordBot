using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using LandlordApp.Repositories;
using LandlordApp.DomainModel.Entities;
using System.Threading;
using System.Globalization;

namespace LandlordApp.Dialogs.States
{
    [Serializable]
    public class CreateIncomeState : ILandlordState
    {

        public static string ProvideIncomeMessage = "Please provide income in the following format: start date, frequency, amount e.g. 15/12/16, monthly, 1600";
        public static string GreetingIncomeMessage = "Hi, How are you doing? What would you like to do? (wave)";
        public static string DontUnderstand = "I don't understand :s";

        private ILandlordState _nextState;

        //private enum RentFrequency
        //{
        //    Unknown,
        //    Monthly
        //}

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
            if (parts.Length != 3)
            {
                return "You need to provide 3 pieces of information frequency and amount";
            }

            var startDateText = parts[0].Trim();
            var frequencyText = parts[1].Trim();
            var amountText = parts[2].Trim();

            DateTime startDate;
            if (!DateTime.TryParse(startDateText, out startDate)) {
                return "I don't understand the start date \"" + startDateText + "\". Please enter correct date.";
            }

            //if (System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern == "M/d/yyyy") {
            //    if (!DateTime.TryParse(startDateText, out startDate)) {
            //        return "I don't understand the start date \"" + startDateText + "\". Please enter correct date.";
            //    }
            //}
            //else {
            //    if (!DateTime.TryParse(startDateText, out startDate)) {
            //        return "I don't understand the start date \"" + startDateText + "\". Please enter correct date.";
            //    }
            //}

            var frequency = Frequency.Unknown;

            switch (frequencyText)
            {
                case "monthly":
                    frequency = Frequency.Monthly;
                    break;
                default:
                    break;
            }

            if (frequency == Frequency.Unknown)
            {
                return "I don't understand the frequency \"" + frequencyText + "\". Please use either weekly, monthly, quarterly or annually.";
            }

            decimal amount = 0;
            if (!decimal.TryParse(amountText, out amount))
            {
                return "Amount needs to be a number";
            }

            // create income
            try {
                Income income = new Income();
                income.RentAmount = amount;
                income.RentFrequency = frequency;
                income.Property = new Property() { PropertyId = 1 };
                income.StartDate = startDate;

                IncomeGateway incomeGateway = new IncomeGateway();
                incomeGateway.CreateIncome(income);
            } catch (Exception ex) {
                return "Error creating income (wasntme) : " + ex.Message;
            }

            _nextState = new InitialState();
            return "Income created successfully (Y) " + startDate.ToShortDateString() + ", " + amount.ToString("£###,###,##0.00") + " (" + Enum.GetName(typeof(Frequency), frequency) + ")";

        }

        public string CreateProperty(IDialogContext context, LuisResult result)
        {
            throw new NotImplementedException();
        }
    }
}