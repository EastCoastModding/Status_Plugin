using System;
using LSPD_First_Response.Mod.API;
using Rage;
using Status_Plugin;

namespace Status_Plugin.Statuses
{
    class ShowMe10_58
    {
        public bool ShowMe10_58Func()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Main.IsTSBackupRequired = true;
            Game.DisplayNotification("~r~Status Plugin: ~u~Showing You 10-58 (Direct Traffic Stop)");
            Game.DisplayNotification("~r~Status Plugin: ~u~Is Backup Required?");
            Functions.PlayScannerAudio("10_4");
            return true;
        }
    }
}
