using System;
using LSPD_First_Response.Mod.API;
using Rage;
using UltimateBackup;

namespace Status_Plugin.Statuses
{
    class Affirmative : Plugin
    {
        VocalDispatchHelper VDHelper = new VocalDispatchHelper();

        public override void Initialize()
        {
            if (Utilities.IsLSPDFRPluginRunning("VocalDispatch", new System.Version(1, 5, 0, 0)) == true)
            {
                try
                {
                    VDHelper.SetupVocalDispatchAPI("StatusPlugin.Affirmative", new Utilities.VocalDispatchEventDelegate(AffirmativeFunc));
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


        public bool AffirmativeFunc()
        {
            if (ShowMe10_58.IsTSBackupRequired == true)
            {
                if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
                {
                    if (Functions.IsPlayerPerformingPullover() == true)
                    {
                        LHandle pullover = Functions.GetCurrentPullover();
                        Vehicle vehicle = Functions.GetPulloverSuspect(pullover).LastVehicle;
                        TrafficStopBackup trafficStopBackup = new TrafficStopBackup(vehicle, TrafficStopResponseType.Normal, "Code 2");
                        trafficStopBackup.callForBackup(1);
                        ShowMe10_58.IsTSBackupRequired = false;
                        Functions.PlayScannerAudio("10_4");
                        Game.DisplayNotification("10-4, Units Responding Code 2");
                    }
                }
                else
                {
                    Game.DisplayNotification("Warning: You require UltimateBackup for this feature.");
                }
            }
            return true;
        }
    }
}
