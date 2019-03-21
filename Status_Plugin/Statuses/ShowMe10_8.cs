using System;
using LSPD_First_Response.Mod.API;
using Rage;
using VocalDispatch;


namespace Status_Plugin.Statuses
{
    class ShowMe10_8
    {
        public bool ShowMe10_8Func()
        {
            Functions.SetPlayerAvailableForCalls(true);
            Game.DisplayNotification("Showing 10-8 (Available)");
            Functions.PlayScannerAudio("10_4");
            return true;
        }
    }
}
