using System;
using LSPD_First_Response.Mod.API;
using Rage;
using VocalDispatch;
using Arrest_Manager;

namespace Status_Plugin.Statuses
{
    class ShowMe10_7
    {
        public bool ShowMe10_7Func()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("Showing 10-7 (Busy)");
            Functions.PlayScannerAudio("10_4");
            return true;
        }
    }
}
