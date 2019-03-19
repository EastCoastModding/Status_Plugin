using System;
using LSPD_First_Response.Mod.API;
using Rage;

namespace Status_Plugin.Statuses
{
    class Negative : Plugin
    {
        VocalDispatchHelper VDHelper = new VocalDispatchHelper();

        public override void Initialize()
        {
            if (Utilities.IsLSPDFRPluginRunning("VocalDispatch", new System.Version(1, 5, 0, 0)) == true)
            {
                try
                {
                    VDHelper.SetupVocalDispatchAPI("StatusPlugin.Negative", new Utilities.VocalDispatchEventDelegate(NegativeFunc));
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

        public bool NegativeFunc()
        {
            Game.DisplayNotification("10_4");
            Functions.PlayScannerAudio("10_4");
            ShowMe10_58.IsTSBackupRequired = false;
            return true;
        }
    }
}
