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
        private static Guid guid10_52;
        private static Guid guid10_53;
        private static Guid guid10_71;
        private static Guid guid10_99;
        private static Guid guidcode5;
        private static Guid guidsignal100;
        private static Guid guidAffirmative;
        private static Guid guidNegative;
        //</Guid>

        internal static void Main()
        {
            General general = new General();
            Backup statuses = new Backup();
            Services services = new Services();
            Signals signals = new Signals();
            TrafficStop trafficStop = new TrafficStop();

            guid10_5 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_5", services.ShowMe10_5);
            guid10_6 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_6", services.ShowMe10_6);
            guid10_7 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_7", services.ShowMe10_7);
            guid10_8 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_8", services.ShowMe10_8);
            guid10_11O1 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O1", trafficStop.ShowMe10_11O1);
            guid10_11O2 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O2", trafficStop.ShowMe10_11O2);
            guid10_11O3 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O3", trafficStop.ShowMe10_11O3);
            guid10_11O4 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O4", trafficStop.ShowMe10_11O4);
            guid10_15 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_15", general.ShowMe10_15);
            guid10_19 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_19", general.ShowMe10_19);
            guid10_23 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_23", general.ShowMe10_23);
            guid10_32C2 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32C2", statuses.Requesting10_32C2);
            guid10_32C3 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32C3", statuses.Requesting10_32C3);
            guid10_32F = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32F", statuses.Requesting10_32F);
            guid10_32TS = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32TS", statuses.Requesting10_32TS);
            guid10_32K9 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32K9", statuses.Requesting10_32K9);
            guid10_41 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_41", services.ShowMe10_41);
            guid10_42 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_42", services.ShowMe10_42);
            guid10_51 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_51", statuses.Requesting10_51);
            guid10_52 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_52", statuses.Requesting10_52);
            guid10_53 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_53", statuses.Requesting10_53);
            guid10_71 = APIv1.RegisterEventHandler("StatusPlugin.Requesting10_71", statuses.Requesting10_71);
            guid10_99 = APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_99", general.ShowMe10_99);
            guidcode5 = APIv1.RegisterEventHandler("StatusPlugin.ShowMeCode5", trafficStop.ShowMeCode5);
            guidsignal100 = APIv1.RegisterEventHandler("StatusPlugin.Signal100", signals.Signalling100);
            guidAffirmative = APIv1.RegisterEventHandler("StatusPlugin.Affirmative", general.Affirmative);
            guidNegative = APIv1.RegisterEventHandler("StatusPlugin.Negative", general.Negative);

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
            APIv1.UnregisterEventHandler(guid10_52);
            APIv1.UnregisterEventHandler(guid10_53);
            APIv1.UnregisterEventHandler(guid10_71);
            APIv1.UnregisterEventHandler(guid10_99);
            APIv1.UnregisterEventHandler(guidcode5);
            APIv1.UnregisterEventHandler(guidsignal100);
            APIv1.UnregisterEventHandler(guidAffirmative);
            APIv1.UnregisterEventHandler(guidNegative);
            Game.Console.Print(Globals.PluginName + ": Unregistered Vocal Dispatch Commands.");
        }
    }
}
