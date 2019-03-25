using System;
using LSPD_First_Response.Mod.API;
using Rage;
using UltimateBackup;

namespace Officer_Status_Plugin
{
    internal class TS10_12Funcs
    {
        internal bool ShowMe10_12O1()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Globals.IsTSBackupRequired = true;
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing You 10-12 O1 (Traffic Stop Occupied Times 1)");
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Is Backup Required?");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4 IS BACKUP_REQUIRED");
            return true;
        }

        internal bool ShowMe10_12O2()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Globals.IsTSBackupRequired = true;
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing You 10-12 O2 (Traffic Stop Occupied Times 2)");
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Is Backup Required?");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4 IS BACKUP_REQUIRED");
            return true;
        }

        internal bool ShowMe10_12O3()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Globals.IsTSBackupRequired = true;
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing You 10-12 O3 (Traffic Stop Occupied Times 3)");
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Is Backup Required?");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4 IS BACKUP_REQUIRED");
            return true;
        }

        internal bool ShowMe10_12O4()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing You 10-12 O4 (Traffic Stop Occupied Times 4)");
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                Controls.requestTrafficStopBackup(true, TrafficStopResponseType.Normal, "LocalPatrol");
                Globals.IsTSBackupRequired = false;
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudioUsingPosition("10_4 BACKUP_REQUIRED", Game.LocalPlayer.Character.Position);
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~10-4, Units Responding");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": UltimateBackup is required for this feature.");
            }
            return true;
        }
    }
}
