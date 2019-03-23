using VocalDispatch;
using Rage;

namespace Officer_Status_Plugin
{
    class Vocal_Dispatch_Start
    {
        public static void Main()
        {
            Statuses statuses = new Statuses();
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_7", statuses.ShowMe10_7);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_8", statuses.ShowMe10_8);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_19", statuses.ShowMe10_19);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_58", statuses.ShowMe10_58);
            APIv1.RegisterEventHandler("StatusPlugin.Affirmative", statuses.Affirmative);
            APIv1.RegisterEventHandler("StatusPlugin.Negative", statuses.Negative);

            Game.Console.Print(Globals.PluginName + ": Registered all Vocal Dispatch Events");
        }
    }
}
