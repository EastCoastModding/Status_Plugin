using System;
using LSPD_First_Response.Mod.API;
using Rage;

namespace Status_Plugin.Statuses
{
    class ShowMe10_58 : Plugin
    {
        VocalDispatchHelper VDHelper = new VocalDispatchHelper();
        public static bool IsTSBackupRequired = false;

        public override void Initialize()
        {
            try
            {
                VDHelper.SetupVocalDispatchAPI("StatusPlugin.ShowMe10_58", new Utilities.VocalDispatchEventDelegate(ShowMe10_58Func));
            }
            catch (Exception e)
            {
                Rage.Game.Console.Print("Error: " + e.ToString());
            }
        }
        public override void Finally()
        {
            VDHelper.ReleaseVocalDispatchAPI();
        }

        public bool ShowMe10_58Func()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("Showing 10-58 (Direct Traffic Stop)");
            Game.DisplayNotification("Is Backup Required");
            Functions.PlayScannerAudio("10_4");
            Functions.PlayScannerAudio("IS");
            Functions.PlayScannerAudio("BACKUP_REQUIRED");
            IsTSBackupRequired = true;
            return true;
        }
    }
}
