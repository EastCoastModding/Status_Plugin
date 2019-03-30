using LSPD_First_Response.Mod.API;
using Rage;

namespace Officer_Status_Plugin.NorthCarolina
{
    internal static class Services
    {
        internal static bool ShowMe10_5()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-5 (Break)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        internal static bool ShowMe10_6()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-6 (Busy)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        internal static bool ShowMe10_7()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-7 (Out of Service)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        internal static bool ShowMe10_8()
        {
            Functions.SetPlayerAvailableForCalls(true);
            Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-8 (Available)");
            GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
            Functions.PlayScannerAudio("10_4");
            return true;
        }
        internal static bool ShowMe10_41()
        {
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-41 (Beginning Duty)");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
                return true;
            }
        }
        internal static bool ShowMe10_42()
        {
            {
                Functions.SetPlayerAvailableForCalls(false);
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Showing you 10-42 (Ending Duty)");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
                return true;
            }
        }
    }
}
