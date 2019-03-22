using System;
using LSPD_First_Response.Mod.API;
using Rage;

namespace Status_Plugin.Statuses
{
    class ShowMe10_19
    {
        public bool ShowMe10_19Func()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~Status Plugin: ~w~Showing You 10-19 (Returning to Station)");
            Functions.PlayScannerAudio("10_4");
            return true;
        }
    }
}
