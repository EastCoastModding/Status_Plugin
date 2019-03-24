﻿using VocalDispatch;
using Rage;

namespace Officer_Status_Plugin
{
    class Vocal_Dispatch_Start
    {
        public static void Main()
        {
            Statuses statuses = new Statuses();
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_5", statuses.ShowMe10_5);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_6", statuses.ShowMe10_6);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_7", statuses.ShowMe10_7);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_8", statuses.ShowMe10_8);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_12", statuses.ShowMe10_12);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_19", statuses.ShowMe10_19);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_23", statuses.ShowMe10_23);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_41", statuses.ShowMe10_41);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_42", statuses.ShowMe10_42);
            APIv1.RegisterEventHandler("StatusPlugin.Requesting10_51", statuses.Requesting10_51);
            APIv1.RegisterEventHandler("StatusPlugin.Affirmative", statuses.Affirmative);
            APIv1.RegisterEventHandler("StatusPlugin.Negative", statuses.Negative);

            Game.Console.Print(Globals.PluginName + ": Registered all Vocal Dispatch Events");
        }
    }
}
