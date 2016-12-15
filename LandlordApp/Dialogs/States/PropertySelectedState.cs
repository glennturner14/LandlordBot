using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;

namespace LandlordApp.Dialogs.States
{
    [Serializable]
    public class PropertySelectedState : ILandlordState
    {

        private ILandlordState _nextState;
        private int _propertyID;

        public ILandlordState NextState
        {
            get
            {
                return _nextState;
            }
        }

        public PropertySelectedState(int propertyID)
        {
            _propertyID = propertyID;
            _nextState = this;
        }

        public string CaptureExpense()
        {
            throw new NotImplementedException();
        }

        public string CaptureIncome()
        {
            throw new NotImplementedException();
        }

        public string CreateProperty(IDialogContext context, LuisResult result)
        {
            throw new NotImplementedException();
        }

        public string Greeting()
        {
            throw new NotImplementedException();
        }

        public string None(IDialogContext context, LuisResult result)
        {
            return "property id is " + _propertyID.ToString();
        }

        public string ShowStatement(IDialogContext context, LuisResult result)
        {
            throw new NotImplementedException();
        }
    }
}