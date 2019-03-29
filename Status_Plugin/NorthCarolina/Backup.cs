using LSPD_First_Response.Mod.API;
using Rage;
using UltimateBackup;

namespace Officer_Status_Plugin.NorthCarolina
{
    internal class Backup
    {
        internal bool Requesting10_32C2()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                Controls.requestOnSceneBackup(true, OnSceneResponseType.Code2, "LocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Unit Code 2");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool Requesting10_32C3()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                Controls.requestOnSceneBackup(true, OnSceneResponseType.Code3, "LocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Unit Code 3");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool Requesting10_32F()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                Controls.requestOnSceneBackup(true, OnSceneResponseType.Code2, "FemaleLocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Female Unit");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool Requesting10_32TS()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                Controls.requestTrafficStopBackup(true, TrafficStopResponseType.Normal , "LocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Code 2 Unit");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool Requesting10_32K9()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                Controls.requestOnSceneBackup(true, OnSceneResponseType.Code2, "K9LocalPatrol");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching K9 Unit");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool Requesting10_51()
        {
            if (Utilities.IsLSPDFRPluginRunning("StopThePed"))
            {
                bool CarFound = StopThePed.Controls.requestTowFromVocalDispatch();
                if (CarFound)
                {
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Tow Truck");
                    GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                    Functions.PlayScannerAudio("10_4");
                }
                else
                {
                    Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Unable to Dispatch Tow Truck");
                }
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require StopThePed for this Feature");
            }
            return true;
        }
        internal bool Requesting10_52()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                Controls.requestAmbulanceUnit(true, true, "Ambulance");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching EMS");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool Requesting10_53()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                Controls.requestFireTruckUnit(true, true, "FireTruck");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Firetruck");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
        internal bool Requesting10_71()
        {
            if (Utilities.IsLSPDFRPluginRunning("UltimateBackup"))
            {
                Controls.requestOnSceneBackup(true, OnSceneResponseType.Code2, "Supervisor");
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~Dispatching Supervisor Code 2");
                GameFiber.SleepWhile(Functions.GetIsAudioEngineBusy, 100000);
                Functions.PlayScannerAudio("10_4");
            }
            else
            {
                Game.DisplayNotification("~r~" + Globals.PluginName + ": ~w~You Require Ultimate Backup for this Feature");
            }
            return true;
        }
    }
}
