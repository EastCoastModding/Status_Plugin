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
                Utilities.GetIni();

                if (Globals.State == "NorthCarolina")
                {
                    NorthCarolina.Menu.Main();

                    if (Utilities.IsLSPDFRPluginRunning("VocalDispatch"))
                    {
                        NorthCarolina.Vocal_Dispatch_Start.Main();
                    }

                }

                Game.DisplayNotification("~r~" + Globals.PluginName + " v" + Globals.version + " By OfficerPope: ~w~Has loaded successfully, thank you for downloading! Welcome on Duty, " + Globals.Unit);
            }
        }

        public override void Finally()
        {
            if (Globals.State == "NorthCarolina")
            {
                NorthCarolina.Menu.Stop();

                if (Utilities.IsLSPDFRPluginRunning("VocalDispatch"))
                {
                    NorthCarolina.Vocal_Dispatch_Start.Stop();
                }

            }

            Game.LogTrivial(Globals.PluginName + " has cleaned up.");
        }
    }
}
