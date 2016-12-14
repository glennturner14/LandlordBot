using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LandlordApp.Dialogs {

    [Serializable]
    [LuisModel("17acd4d0-7ace-4ebe-ad71-89e7a3cc7512", "fb109555-6c75-422e-b4ad-dbaa254c246f"]
    public class LandlordDialog : LuisDialog<object> {
        /// <summary>
        /// Deal with anything unknown
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result) {
            string message = "unknown";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
    }
}