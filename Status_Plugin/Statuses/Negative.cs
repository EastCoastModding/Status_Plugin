﻿using System;
using LSPD_First_Response.Mod.API;
using Rage;

namespace Status_Plugin.Statuses
{
    class Negative
    {
        public bool NegativeFunc()
        {
            Game.DisplayNotification("Status Plugin: 10-4");
            Functions.PlayScannerAudio("10_4");
            Main.IsTSBackupRequired = false;
            return true;
        }
    }
}
