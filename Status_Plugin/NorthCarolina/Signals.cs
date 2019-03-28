using LSPD_First_Response;
using Rage;

namespace Officer_Status_Plugin.NorthCarolina
{
    internal class Signals
    {
        bool signalling100 = false;
        internal bool Signalling100()
        {
            if (Utilities.IsLSPDFRPluginRunning("StopThePed"))
            {
                if (signalling100)
                {
                    signalling100 = false;
                    StopThePed.Actions.deactivateTrafficControl();
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Removing Signal 100");
                }
                else
                {
                    signalling100 = true;
                    StopThePed.Actions.activateTrafficControl(true);
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Initializing Signal 100");
                }
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require StopThePed for this Feature");
            }
            return true;
        }
    }
}
