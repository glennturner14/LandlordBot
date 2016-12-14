using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandlordApp.Dialogs.States {

    public interface ILandlordState {

        string None();

        string Greeting();

        string CaptureIncome();

        string CaptureExpense();

        string ShowStatement();

        ILandlordState NextState { get; }

    }
}
