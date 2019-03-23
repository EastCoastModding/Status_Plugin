using LSPD_First_Response.Mod.API;
using Rage;

namespace Status_Plugin
{
    public class Main : Plugin
    {
        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += Functions_OnOnDutyStateChanged;

            Game.LogTrivial("Status Plugin " + Globals.version + " has been Initialized.");
        }

        private void Functions_OnOnDutyStateChanged(bool onDuty)
        {
            if (onDuty)
            {
                Menu.Main();

                if (Utilities.IsLSPDFRPluginRunning("VocalDispatch"))
                {
                    Vocal_Dispatch_Start.Main();
                }

                Game.DisplayNotification("~r~Status Plugin v" + Globals.version + " ~p~By OfficerPope: ~w~Has loaded successfully, thank you for downloading!");
            }
        }

        public override void Finally()
        {
            Menu.Stop();

            Game.LogTrivial("Status Plugin has cleaned up.");
        }
    }
}
