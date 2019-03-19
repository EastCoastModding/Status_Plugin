using System;
using LSPD_First_Response.Mod.API;
using Rage;
using UltimateBackup;

namespace Status_Plugin
{
    public class Main : Plugin
    {

        public Main() { }

        public bool IsTSBackupRequired = false;

        public bool ShowMe1058()
        {
            try
            {
                Functions.SetPlayerAvailableForCalls(false);
                Game.DisplayNotification("Showing 10-58 (Direct Traffic Stop)");
                Functions.PlayScannerAudio("10_4");
                Functions.PlayScannerAudio("IS");
                Functions.PlayScannerAudio("BACKUP_REQUIRED");
                IsTSBackupRequired = true;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Affirmative()
        {
            if (IsTSBackupRequired == true)
            {
                if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
                {
                    if (Functions.IsPlayerPerformingPullover() == true)
                    {
                        LHandle pullover = Functions.GetCurrentPullover();
                        Vehicle vehicle = Functions.GetPulloverSuspect(pullover).LastVehicle;
                        TrafficStopBackup trafficStopBackup = new TrafficStopBackup(vehicle, TrafficStopResponseType.Normal, "Code 2");
                        trafficStopBackup.callForBackup(1);
                        IsTSBackupRequired = false;
                        Functions.PlayScannerAudio("10_4_COPY_1");
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
        public bool Negative()
        {
            if (IsTSBackupRequired == true)
            {
                IsTSBackupRequired = false;
                Functions.PlayScannerAudio("10_4");
                Game.DisplayNotification("10-4");
            }
            return true;
        }

        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;

            Game.LogTrivial("Status Plugin " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " has been Initialized.");
        }

        private static void OnOnDutyStateChangedHandler(bool OnDuty)
        {
            if (OnDuty)
            {
                Game.DisplayNotification("Status Plugin v1.0 has loaded successfully, thank you for downloading!");
            }
        }

        public override void Finally()
        {
            Game.LogTrivial("Status Plugin has cleaned up.");
        }
    }
}
