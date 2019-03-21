using System;
using LSPD_First_Response.Mod.API;
using Rage;
using VocalDispatch;
using Arrest_Manager;

namespace Status_Plugin.Statuses
{
    class ShowMe10_7 : Plugin
    {
        public static void Main() { }

        public bool ShowMe10_7Func()
        {
            try
            {
                Functions.SetPlayerAvailableForCalls(false);
                Game.DisplayNotification("Showing 10-7 (Busy)");
                Functions.PlayScannerAudio("10_4");
            }
            catch (Exception e)
            {
                Game.DisplayNotification("Error:" + e);
                Rage.Game.Console.Print("Error:" + e);
            }
            return true;
        }

        public override void Initialize()
        {
            APIv1.VocalDispatchPhraseNotificationEventHandlerFunction Handler = new APIv1.VocalDispatchPhraseNotificationEventHandlerFunction(ShowMe10_7Func);
            Guid ShowMe10_7guid = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_7", Handler);
        }
        public override void Finally()
        {
        }
    }
}
