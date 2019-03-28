using LSPD_First_Response.Mod.API;
using Rage;
using UltimateBackup;

namespace Officer_Status_Plugin.NorthCarolina
{
    internal class General
    {
        internal bool ShowMe10_15()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-15 (Suspect in Custody, Returning to Station)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        internal bool ShowMe10_19()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing You 10-19 (Returning to Station)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        internal bool ShowMe10_23()
        {
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-23 (Arrived on Scene)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        internal bool Requesting10_28()
        {
            return true;
        }
        internal bool ShowMe10_99()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                Controls.requestPanicBackup(true);
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudioUsingPosition("PANIC_BUTTON BACKUP_REQUIRED", Game.LocalPlayer.Character.Position);
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~All available units respond code 3");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": UltimateBackup is required for this feature.");
            }
            return true;
        }

        internal bool Affirmative()
        {
            if (Globals.IsTSBackupRequired)
            {
                if (Functions.IsPlayerPerformingPullover())
                {
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
                }
                else
                {
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": Traffic stop is not in progress.");
                }
            }
            return true;
        }
        internal bool Negative()
        {
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~10-4");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4 PROCEED_WITH_CAUTION");
            Globals.IsTSBackupRequired = false;
            return true;
        }
    }
}
