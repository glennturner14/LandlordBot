using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;

namespace LandlordApp.Dialogs.States {

    public interface ILandlordState {
        
        string Greeting();

        string CaptureIncome();

        string CaptureExpense();

        string ShowStatement();

        ILandlordState NextState { get; }

        string None(IDialogContext context, LuisResult result);
    }
}
