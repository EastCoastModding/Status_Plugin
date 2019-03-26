using VocalDispatch;
using Rage;

namespace Officer_Status_Plugin
{
    class Vocal_Dispatch_Start
    {
        public static void Main()
        {
            Statuses statuses = new Statuses();
            TS10_11Funcs ts10_11Funcs = new TS10_11Funcs();
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_5", statuses.ShowMe10_5);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_6", statuses.ShowMe10_6);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_7", statuses.ShowMe10_7);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_8", statuses.ShowMe10_8);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O1", ts10_11Funcs.ShowMe10_11O1);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O2", ts10_11Funcs.ShowMe10_11O2);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O3", ts10_11Funcs.ShowMe10_11O3);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_11O4", ts10_11Funcs.ShowMe10_11O4);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_15", statuses.ShowMe10_15);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_19", statuses.ShowMe10_19);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_23", statuses.ShowMe10_23);
            APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32C2", statuses.Requesting10_32C2);
            APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32C3", statuses.Requesting10_32C3);
            APIv1.RegisterEventHandler("StatusPlugin.Requesting10_32F", statuses.Requesting10_32F);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_41", statuses.ShowMe10_41);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_42", statuses.ShowMe10_42);
            APIv1.RegisterEventHandler("StatusPlugin.Requesting10_51", statuses.Requesting10_51);
            APIv1.RegisterEventHandler("StatusPlugin.Requesting10_52", statuses.Requesting10_52);
            APIv1.RegisterEventHandler("StatusPlugin.Requesting10_53", statuses.Requesting10_53);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_99", statuses.ShowMe10_99);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMeCode5", statuses.ShowMeCode5);
            APIv1.RegisterEventHandler("StatusPlugin.Affirmative", statuses.Affirmative);
            APIv1.RegisterEventHandler("StatusPlugin.Negative", statuses.Negative);

            Game.Console.Print(Globals.PluginName + ": Registered all Vocal Dispatch Events");
        }
    }
}
