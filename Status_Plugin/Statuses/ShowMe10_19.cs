using System;
using LSPD_First_Response.Mod.API;
using Rage;

namespace Status_Plugin.Statuses
{
    class ShowMe10_19 : Plugin
    {
        VocalDispatchHelper VDHelper = new VocalDispatchHelper();

        public override void Initialize()
        {
            if (Utilities.IsLSPDFRPluginRunning("VocalDispatch", new System.Version(1, 5, 0, 0)) == true)
            {
                try
                {
                    VDHelper.SetupVocalDispatchAPI("StatusPlugin.ShowMe10_19", new Utilities.VocalDispatchEventDelegate(ShowMe10_19Func));
                }
                catch (Exception e)
                {
                    Rage.Game.Console.Print("Error: " + e.ToString());
                }
            }
        }
        public override void Finally()
        {
            VDHelper.ReleaseVocalDispatchAPI();
        }

        public bool ShowMe10_19Func()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("Showing 10-19 (Returning to Station)");
            Functions.PlayScannerAudio("10_4");
            return true;
        }
    }
}
