using LSPD_First_Response;
using Rage;

namespace Officer_Status_Plugin.NorthCarolina
{
    internal class Signals
    {
        internal bool Signalling100()
        {
            if (Utilities.IsLSPDFRPluginRunning("StopThePed"))
            {
                if (Globals.signalling100)
                {
                    Globals.signalling100 = false;
                    StopThePed.Actions.deactivateTrafficControl();
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Removing Signal 100");
                }
                else
                {
                    Globals.signalling100 = true;
                    StopThePed.Actions.activateTrafficControl(false);
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
