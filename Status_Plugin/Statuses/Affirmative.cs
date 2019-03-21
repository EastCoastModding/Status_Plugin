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
            if (Main.IsTSBackupRequired)
            {
                if (Functions.IsPlayerPerformingPullover())
                {
                    Controls.requestTrafficStopBackup(true, TrafficStopResponseType.Normal, "LocalPatrol");
                    Main.IsTSBackupRequired = false;
                    Functions.PlayScannerAudio("10_4");
                    Game.DisplayNotification("~r~Status Plugin: ~u~10-4, Units Responding Code 2");
                }
            }
            return true;
        }
    }
}
