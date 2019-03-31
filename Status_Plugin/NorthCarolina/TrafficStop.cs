using LSPD_First_Response.Mod.API;
using Rage;
using UltimateBackup;

namespace Officer_Status_Plugin.NorthCarolina
{
    internal static class TrafficStop
    {
        internal static bool ShowMe10_11O1()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Globals.IsTSBackupRequired = true;
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing You 10-11 O1 (Traffic Stop Occupied Times 1)");
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Is Backup Required?");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4 IS BACKUP_REQUIRED");
            return true;
        }
        internal static bool ShowMe10_11O2()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Globals.IsTSBackupRequired = true;
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing You 10-11 O2 (Traffic Stop Occupied Times 2)");
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Is Backup Required?");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4 IS BACKUP_REQUIRED");
            return true;
        }
        internal static bool ShowMe10_11O3()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Globals.IsTSBackupRequired = true;
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing You 10-11 O3 (Traffic Stop Occupied Times 3)");
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Is Backup Required?");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4 IS BACKUP_REQUIRED");
            return true;
        }
        internal static bool ShowMe10_11O4()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing You 10-11 O4 (Traffic Stop Occupied Times 4)");
            Backup.Requesting10_32TS();
            return true;
        }
        internal static bool ShowMeCode5()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Backup.Requesting10_32FS();
            return true;
        }
    }
}
