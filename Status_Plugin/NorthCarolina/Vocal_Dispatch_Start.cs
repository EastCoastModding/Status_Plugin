using VocalDispatch;
using Rage;
using System;

namespace Officer_Status_Plugin.NorthCarolina
{
    internal class Vocal_Dispatch_Start
    {
        //<Guid>
        private static Guid guid10_5;
        private static Guid guid10_6;
        private static Guid guid10_7;
        private static Guid guid10_8;
        private static Guid guid10_11O1;
        private static Guid guid10_11O2;
        private static Guid guid10_11O3;
        private static Guid guid10_11O4;
        private static Guid guid10_15;
        private static Guid guid10_19;
        private static Guid guid10_23;
        private static Guid guid10_32C2;
        private static Guid guid10_32C3;
        private static Guid guid10_32F;
        private static Guid guid10_32TS;
        private static Guid guid10_32K9;
        private static Guid guid10_41;
        private static Guid guid10_42;
        private static Guid guid10_51;
        private static Guid guid10_52I;
        private static Guid guid10_52F;
        private static Guid guid10_53;
        private static Guid guid10_71;
        private static Guid guid10_99;
        private static Guid guidcode5;
        private static Guid guidAffirmative;
        private static Guid guidNegative;
        //</Guid>

        internal static void Main()
        {
            guid10_5 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_5", Services.ShowMe10_5);
            guid10_6 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_6", Services.ShowMe10_6);
            guid10_7 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_7", Services.ShowMe10_7);
            guid10_8 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_8", Services.ShowMe10_8);
            guid10_11O1 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O1", TrafficStop.ShowMe10_11O1);
            guid10_11O2 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O2", TrafficStop.ShowMe10_11O2);
            guid10_11O3 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O3", TrafficStop.ShowMe10_11O3);
            guid10_11O4 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O4", TrafficStop.ShowMe10_11O4);
            guid10_15 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_15", General.ShowMe10_15);
            guid10_19 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_19", General.ShowMe10_19);
            guid10_23 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_23", General.ShowMe10_23);
            guid10_41 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_41", Services.ShowMe10_41);
            guid10_42 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_42", Services.ShowMe10_42);
            guid10_99 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_99", General.ShowMe10_99);
            guidcode5 = APIv1.RegisterEventHandler("StatusPlugin.ShowMeCode5", TrafficStop.ShowMeCode5);
            guidAffirmative = APIv1.RegisterEventHandler("StatusPlugin.Affirmative", General.Affirmative);
            guidNegative = APIv1.RegisterEventHandler("StatusPlugin.Negative", General.Negative);

            if (Globals.UltimateBackupDep)
            {
                guid10_32C2 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32C2", Backup.Requesting10_32C2);
                guid10_32C3 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32C3", Backup.Requesting10_32C3);
                guid10_32F = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32F", Backup.Requesting10_32F);
                guid10_32TS = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32TS", Backup.Requesting10_32TS);
                guid10_32K9 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32K9", Backup.Requesting10_32K9);
                guid10_52I = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_52I", Backup.Requesting10_52I);
                guid10_52F = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_52F", Backup.Requesting10_52F);
                guid10_53 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_53", Backup.Requesting10_53);
                guid10_71 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_71", Backup.Requesting10_71);
            }
            if (Globals.StopThePedDep)
            {
                guid10_51 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_51", Backup.Requesting10_51);
            }

            Game.Console.Print(Globals.PluginName + ": Registered Vocal Dispatch Commands.");
        }

        internal static void Stop()
        {
            APIv1.UnregisterEventHandler(guid10_5);
            APIv1.UnregisterEventHandler(guid10_6);
            APIv1.UnregisterEventHandler(guid10_7);
            APIv1.UnregisterEventHandler(guid10_8);
            APIv1.UnregisterEventHandler(guid10_11O1);
            APIv1.UnregisterEventHandler(guid10_11O2);
            APIv1.UnregisterEventHandler(guid10_11O3);
            APIv1.UnregisterEventHandler(guid10_11O4);
            APIv1.UnregisterEventHandler(guid10_15);
            APIv1.UnregisterEventHandler(guid10_19);
            APIv1.UnregisterEventHandler(guid10_23);
            APIv1.UnregisterEventHandler(guid10_32C2);
            APIv1.UnregisterEventHandler(guid10_32C3);
            APIv1.UnregisterEventHandler(guid10_32F);
            APIv1.UnregisterEventHandler(guid10_32TS);
            APIv1.UnregisterEventHandler(guid10_32K9);
            APIv1.UnregisterEventHandler(guid10_41);
            APIv1.UnregisterEventHandler(guid10_42);
            APIv1.UnregisterEventHandler(guid10_51);
            APIv1.UnregisterEventHandler(guid10_52I);
            APIv1.UnregisterEventHandler(guid10_52F);
            APIv1.UnregisterEventHandler(guid10_53);
            APIv1.UnregisterEventHandler(guid10_71);
            APIv1.UnregisterEventHandler(guid10_99);
            APIv1.UnregisterEventHandler(guidcode5);
            APIv1.UnregisterEventHandler(guidAffirmative);
            APIv1.UnregisterEventHandler(guidNegative);
            Game.Console.Print(Globals.PluginName + ": Unregistered Vocal Dispatch Commands.");
        }
    }
}
