using LSPD_First_Response.Mod.API;
using Rage;

using UltimateBackup;

namespace Officer_Status_Plugin.NorthCarolina
{
    internal static class Backup
    {
        internal static bool Requesting10_32C2()
        {
            if (Globals.UltimateBackupDep)
            {
                Controls.requestOnSceneBackup(true, OnSceneResponseType.Code2, "LocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Unit Code 2");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal static bool Requesting10_32C3()
        {
            if (Globals.UltimateBackupDep)
            {
                Controls.requestOnSceneBackup(true, OnSceneResponseType.Code3, "LocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Unit Code 3");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal static bool Requesting10_32F()
        {
            if (Globals.UltimateBackupDep)
            {
                Controls.requestOnSceneBackup(true, OnSceneResponseType.Code2, "FemaleLocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Female Unit");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal static bool Requesting10_32TS()
        {
            if (Globals.UltimateBackupDep)
            {
                Controls.requestTrafficStopBackup(true, TrafficStopResponseType.Normal , "LocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Code 2 Unit");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal static bool Requesting10_32FS()
        {
            if (Globals.UltimateBackupDep)
            {
                Controls.requestTrafficStopBackup(true, TrafficStopResponseType.Felony, "LocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Code 3 Units");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal static bool Requesting10_32K9()
        {
            if (Globals.UltimateBackupDep)
            {
                Controls.requestTrafficStopBackup(true, TrafficStopResponseType.Normal, "K9LocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching K9 Unit");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }

        internal static bool Requesting10_51()
        {
            if (Globals.StopThePedDep)
            {
                StopThePed.Controls.requestTowFromVocalDispatch();
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Tow Truck");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require StopThePed for this Feature");
            }
            return true;
        }

        internal static bool Requesting10_52I()
        {
            if (Globals.UltimateBackupDep)
            {
                Controls.requestAmbulanceUnit(true, true, "Ambulance");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching EMS (Injuries)");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal static bool Requesting10_52F()
        {
            if (Globals.UltimateBackupDep)
            {
                Controls.requestAmbulanceUnit(true, true, "Ambulance");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching EMS (Fatalities)");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }

        internal static bool Requesting10_53()
        {
            if (Globals.UltimateBackupDep)
            {
                Controls.requestFireTruckUnit(true, true, "FireTruck");
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

        internal static bool Requesting10_71()
        {
            if (Globals.UltimateBackupDep)
            {
                if (Functions.IsPlayerPerformingPullover())
                {
                    Controls.requestTrafficStopBackup(true, TrafficStopResponseType.Normal, "Supervisor");
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Supervisor Code 2");
                }
                Controls.requestOnSceneBackup(true, OnSceneResponseType.Code2, "Supervisor");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Supervisor Code 2");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }

        internal static void Requesting10_99()
        {
            Controls.requestPanicBackup(true);
        }
    }
}
