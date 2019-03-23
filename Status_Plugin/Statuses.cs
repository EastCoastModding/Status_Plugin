using LSPD_First_Response.Mod.API;
using Rage;
using UltimateBackup;


namespace Status_Plugin
{
    public class Statuses
    {
        public bool ShowMe10_7()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~Status Plugin: ~w~Showing you 10-7 (Busy)");
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        public bool ShowMe10_8()
        {
            Functions.SetPlayerAvailableForCalls(true);
            Game.DisplayNotification("~r~Status Plugin: ~w~Showing you 10-8 (Available)");
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        public bool ShowMe10_19()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~Status Plugin: ~w~Showing You 10-19 (Returning to Station)");
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        public bool ShowMe10_58()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Globals.IsTSBackupRequired = true;
            Game.DisplayNotification("~r~Status Plugin: ~w~Showing You 10-58 (Direct Traffic Stop)");
            Game.DisplayNotification("~r~Status Plugin: ~w~Is Backup Required?");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4 IS BACKUP_REQUIRED");
            return true;
        }
        public bool Affirmative()
        {
            if (Globals.IsTSBackupRequired)
            {
                if (Functions.IsPlayerPerformingPullover() && Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
                {
                    if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
                    {
                        Controls.requestTrafficStopBackup(true, TrafficStopResponseType.Normal, "LocalPatrol");
                        Globals.IsTSBackupRequired = false;
                        Functions.PlayScannerAudioUsingPosition("10_4 BACKUP_REQUIRED", Game.LocalPlayer.Character.Position);
                        Game.DisplayNotification("~r~Status Plugin: ~w~10-4, Units Responding");
                    }
                    else
                    {
                        Game.DisplayNotification("~r~Status Plugin: " + "UltimateBackup is required for this feature.");
                    }
                }
                else
                {
                    Game.DisplayNotification("~r~Status Plugin: " + "Traffic stop is not in progress.");
                }
            }
            return true;
        }
        public bool Negative()
        {
            Game.DisplayNotification("~r~Status Plugin: ~w~10-4");
            Functions.PlayScannerAudio("10_4");
            Globals.IsTSBackupRequired = false;
            return true;
        }


    }
}
