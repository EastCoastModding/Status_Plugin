using System;
using LSPD_First_Response.Mod.API;
using Rage;
using VocalDispatch;

namespace Status_Plugin.Statuses
{
    class ShowMe10_7 : Plugin
    {
        VocalDispatchHelper MyVocalDispatchHelper = new VocalDispatchHelper();
        public override void Initialize()
        {
            MyVocalDispatchHelper.SetupVocalDispatchAPI("StatusPlugin.ShowMe10_7", ShowMe10_7Func);
        }
        public override void Finally()
        {
            MyVocalDispatchHelper.ReleaseVocalDispatchAPI();
        }

        public bool ShowMe10_7Func()
        {
            try
            {
                Functions.SetPlayerAvailableForCalls(false);
                Game.DisplayNotification("Showing 10-7 (Busy)");
                Functions.PlayScannerAudio("10_4");
                return true;
            }
            catch (Exception e)
            {
                Game.DisplayNotification("Error:" + e);
                Rage.Game.Console.Print("Error:" + e);
                return false;
            }
        }
    }
}
