using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using LandlordApp.Repositories;
using LandlordApp.DomainModel.Entities;

namespace LandlordApp.Dialogs.States
{
    [Serializable]
    public class CreateIncomeState : ILandlordState
    {

        public static string ProvideIncomeMessage = "Please provide income in the following format frequency, amount e.g. monthly, 1600";
        public static string GreetingIncomeMessage = "Hi, How are you doing? What would you like to do?";
        public static string DontUnderstand = "I don't understand";

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

        public string ShowStatement()
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
                income.StartDate = new DateTime(2016, 1, 1);

                IncomeGateway incomeGateway = new IncomeGateway();
                incomeGateway.CreateIncome(income);
            } catch (Exception ex) {
                return "Error creating income: " + ex.Message;
            }

            _nextState = new InitialState();
            return "Income created successfully " + amount.ToString("£###,###,##0.00") + " (" + Enum.GetName(typeof(Frequency), frequency) + ")";

        }
    }
}