using Rage;

namespace Officer_Status_Plugin.NorthCarolina
{
    internal static class Signals
    {
        internal static bool Signal60()
        {
            if (Globals.UltimateBackupDep)
            {
                UltimateBackupFuncs.RequestTrafficStop(1, "K9LocalPatrol");
                UltimateBackupFuncs.RequestTrafficStop(1, "Supervisor");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Units Code 3");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
    }
}
