using LSPD_First_Response.Mod.API;
using Rage;
using UltimateBackup;

namespace Officer_Status_Plugin
{
    public class Statuses
    {
        public bool ShowMe10_5()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-5 (Break)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        public bool ShowMe10_6()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-6 (Busy)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        public bool ShowMe10_7()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-7 (Out of Service)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        public bool ShowMe10_8()
        {
            Functions.SetPlayerAvailableForCalls(true);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-8 (Available)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        public bool ShowMe10_15()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-15 (Suspect in Custody, Returning to Station)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        public bool ShowMe10_19()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing You 10-19 (Returning to Station)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        public bool ShowMe10_23()
        {
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-23 (Arrived on Scene)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        public bool ShowMe10_41()
        {
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-41 (Begining Duty)");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
                return true;
            }
        }
        public bool ShowMe10_42()
        {
            {
                Functions.SetPlayerAvailableForCalls(false);
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-42 (Ending Duty)");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
                return true;
            }
        }
        public bool Requesting10_51()
        {
            if (Utilities.IsLSPDFRPluginRunning("StopThePed"))
            {
                bool CarFound = StopThePed.Controls.requestTowFromVocalDispatch();
                if (CarFound)
                {
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Tow Truck");
                    GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                    Functions.PlayScannerAudio("10_4");
                }
                else
                {
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Unable to Dispatch Tow Truck");
                }
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require StopThePed for this Feature");
            }
            return true;
        }
        public bool Affirmative()
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
        public bool Negative()
        {
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~10-4");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            Globals.IsTSBackupRequired = false;
            return true;
        }
    }
}
