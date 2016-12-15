using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandlordApp.Dialogs.States {
    [Serializable]
    public abstract class BaseState {
        

        public static string MESSAGE_GREETING = "Hi, How are you doing? What would you like to do? (wave)";
        public static string MESSAGE_DONTUNDERSTAND = "I don't understand";
        public static string MESSAGE_SHOWSTATEMENT = "Here's your current statement";

        public string StatePrefix { get; internal set; }

        public BaseState() {
        }

        public string GetStateMessage(string msg) {
            return string.Format("{0}-{1}", StatePrefix, msg);
        }
    }
}