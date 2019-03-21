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
            Game.DisplayNotification("Showing 10-58 (Direct Traffic Stop)");
            Game.DisplayNotification("Is Backup Required");
            Functions.PlayScannerAudio("10_4");
            Functions.PlayScannerAudio("IS");
            Functions.PlayScannerAudio("BACKUP_REQUIRED");
            Main.IsTSBackupRequired = true;
            return true;
        }
    }
}
