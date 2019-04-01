using LSPD_First_Response.Mod.API;
using Rage;

namespace Officer_Status_Plugin.NorthCarolina
{
    internal static class Backup
    {
        internal static bool Requesting10_32C2()
        {
            if (Globals.UltimateBackupDep)
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
        internal static bool Requesting10_32C3()
        {
            if (Globals.UltimateBackupDep)
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
        internal static bool Requesting10_32F()
        {
            if (Globals.UltimateBackupDep)
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
        internal static bool Requesting10_32TS()
        {
            if (Globals.UltimateBackupDep)
            {
                if (Functions.IsPlayerPerformingPullover())
                {
                    UltimateBackupFuncs.RequestTrafficStop(1, "LocalPatrol");
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Code 2 Unit");
                }
                else
                {
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Traffic stop is not in progress.");
                }
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
                if (Functions.IsPlayerPerformingPullover())
                {
                    UltimateBackupFuncs.RequestTrafficStop(2, "LocalPatrol");
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Code 3 Units");
                }
                else
                {
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Traffic stop is not in progress.");
                }
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
                if (Functions.IsPlayerPerformingPullover())
                {
                    UltimateBackupFuncs.RequestTrafficStop(1, "K9LocalPatrol");
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching K9 Unit");
                }
                else
                {
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Traffic stop is not in progress.");
                }
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }

        internal static bool Requesting10_38()
        {
            if (Globals.UltimateBackupDep)
            {
                if (Functions.IsPedInPursuit(Game.LocalPlayer.Character))
                {
                    UltimateBackupFuncs.RequestRoadBlockUnits();
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Roadblock Units");
                }
                else
                {
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Pursuit is not in progress.");
                }
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
                StopThePedFuncs.RequestTowTruck();
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
                UltimateBackupFuncs.RequestAmbulanceUnit("Ambulance");
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
                UltimateBackupFuncs.RequestAmbulanceUnit("Ambulance");
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
                UltimateBackupFuncs.RequestFireTruckUnit("FireTruck");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Firetruck");
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
                    UltimateBackupFuncs.RequestTrafficStop(1,"Supervisor");
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Supervisor Code 2");
                }
                UltimateBackupFuncs.RequestOnSceneBackup(2, "Supervisor");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Supervisor Code 2");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal static bool Requesting10_72()
        {
            if (Globals.UltimateBackupDep)
            {
                if (Functions.IsPedInPursuit(Game.LocalPlayer.Character))
                {
                    UltimateBackupFuncs.RequestPursuitBackup("LocalAir");
                }
                else
                {
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Pursuit is not in progress.");
                }
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
    }
}
