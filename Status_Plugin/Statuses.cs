using LSPD_First_Response.Mod.API;
using Rage;
using UltimateBackup;

namespace Officer_Status_Plugin
{
    internal class Statuses
    {
        internal bool ShowMe10_5()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-5 (Break)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        internal bool ShowMe10_6()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-6 (Busy)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        internal bool ShowMe10_7()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-7 (Out of Service)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        internal bool ShowMe10_8()
        {
            Functions.SetPlayerAvailableForCalls(true);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-8 (Available)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
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
        internal bool Requesting10_32C2()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                UltimateBackupFuncs.RequestOnSceneBackup(2, "LocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Unit Code 2");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool Requesting10_32C3()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                UltimateBackupFuncs.RequestOnSceneBackup(3, "LocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Unit Code 3");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool Requesting10_32F()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                UltimateBackupFuncs.RequestOnSceneBackup(2, "FemaleLocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Female Unit");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool ShowMe10_41()
        {
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-41 (Beginning Duty)");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
                return true;
            }
        }
        internal bool ShowMe10_42()
        {
            {
                Functions.SetPlayerAvailableForCalls(false);
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-42 (Ending Duty)");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
                return true;
            }
        }
        internal bool Requesting10_51()
        {
            if (Utilities.IsLSPDFRPluginRunning("StopThePed"))
            {
                StopThePedFuncs.RequestTowTruck();
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Tow Truck");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require StopThePed for this Feature");
            }
            return true;
        }
        internal bool Requesting10_52()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                UltimateBackupFuncs.RequestAmbulanceUnit("Ambulance");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching EMS");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool Requesting10_53()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                UltimateBackupFuncs.RequestFireTruckUnit("Firetruck");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Firetruck");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool ShowMe10_99()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                UltimateBackupFuncs.PanicUnits();
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
                        UltimateBackupFuncs.RequestTrafficStop(1, "LocalPatrol");
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

        internal bool ShowMeCode5()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                UltimateBackupFuncs.RequestTrafficStop(2, "LocalPatrol");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudioUsingPosition("10_4 BACKUP_REQUIRED", Game.LocalPlayer.Character.Position);
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you Code 5 (Felony Stop)");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": UltimateBackup is required for this feature.");
            }
            return true;
        }
    }
}
