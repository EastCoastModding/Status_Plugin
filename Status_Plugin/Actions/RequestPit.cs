using Rage;

namespace Officer_Status_Plugin.Actions
{
    internal static class RequestPit
    {
        private static int weather;
        private static string[] WeatherTypes;
        
        internal static void Main()
        {
            weather = (int)World.Weather;
            if (weather >= 10 || weather == 6 || weather == 7)
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You are not clear to pit at this time, due to the ~y~Weather Conditions");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You are cleared to pit at this time, ~y~Weather Conditions ~w~are safe");
            }
        }
    }
}
