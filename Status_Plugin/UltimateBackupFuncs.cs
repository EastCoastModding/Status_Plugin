using UltimateBackup;

namespace Officer_Status_Plugin
{
    internal static class UltimateBackupFuncs
    {
        internal static void RequestOnSceneBackup(int responseInt, string backupType)
        {
            OnSceneResponseType responseType;
            if(responseInt == 2) { responseType = OnSceneResponseType.Code2; } else { responseType = OnSceneResponseType.Code3; }
            Controls.requestOnSceneBackup(true, responseType, backupType);
        }

        internal static void RequestTrafficStop(int responseInt, string backupType)
        {
            TrafficStopResponseType responseType;
            if (responseInt == 2) { responseType = TrafficStopResponseType.Felony; } else { responseType = TrafficStopResponseType.Normal; }
            Controls.requestTrafficStopBackup(true, responseType, backupType);
        }

        internal static void RequestAmbulanceUnit(string backupType)
        {
            Controls.requestAmbulanceUnit(true, true, backupType);
        }

        internal static void RequestFireTruckUnit(string backupType)
        {
            Controls.requestFireTruckUnit(true, true, backupType);
        }

        internal static void PanicUnits()
        {
            Controls.requestPanicBackup(true);
        }
    }
}
