using System;
using LSPD_First_Response.Mod.API;
using Rage;
using UltimateBackup;

namespace Status_Plugin.Statuses
{
    class Affirmative
    {
        public bool AffirmativeFunc()
        {
            if (Main.IsTSBackupRequired == true)
            {
                if (Functions.IsPlayerPerformingPullover() == true)
                {
                    LHandle pullover = Functions.GetCurrentPullover();
                    Vehicle vehicle = Functions.GetPulloverSuspect(pullover).LastVehicle;
                    TrafficStopBackup trafficStopBackup = new TrafficStopBackup(vehicle, TrafficStopResponseType.Normal, "Code 2");
                    trafficStopBackup.callForBackup(1);
                    Main.IsTSBackupRequired = false;
                    Functions.PlayScannerAudio("10_4");
                    Game.DisplayNotification("10-4, Units Responding Code 2");
                }
            }
            return true;
        }
    }
}
