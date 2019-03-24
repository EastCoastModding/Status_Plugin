using LSPD_First_Response.Mod.API;
using Rage;

namespace Officer_Status_Plugin
{
    public class Main : Plugin
    {
        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += Functions_OnOnDutyStateChanged;

            Game.LogTrivial(Globals.PluginName + Globals.version + " has been Initialized.");
        }

        private void Functions_OnOnDutyStateChanged(bool onDuty)
        {
            if (onDuty)
            {
                Menu.Main();

                Utilities.GetIni();

                if (Utilities.IsLSPDFRPluginRunning("VocalDispatch"))
                {
                    Vocal_Dispatch_Start.Main();
                }

                Game.DisplayNotification("~r~" + Globals.PluginName + " v" + Globals.version + " By " + Globals.author + ": ~w~Has loaded successfully, thank you for downloading!");
            }
        }

        public override void Finally()
        {
            Menu.Stop();

            Game.LogTrivial(Globals.PluginName + " has cleaned up.");
        }
    }
}
