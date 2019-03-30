using System;
using System.Windows.Forms;
using System.Reflection;
using LSPD_First_Response.Mod.API;
using Rage;
using System.IO;

namespace Officer_Status_Plugin
{
    internal static class Utilities
    {
        internal static bool IsLSPDFRPluginRunning(string Plugin, Version minversion = null)
        {
            foreach (Assembly assembly in Functions.GetAllUserPlugins())
            {
                AssemblyName an = assembly.GetName();
                if (an.Name.ToLower() == Plugin.ToLower())
                {
                    if (minversion == null || an.Version.CompareTo(minversion) >= 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal static void GetDependencies()
        {
            Globals.UltimateBackupDep = IsLSPDFRPluginRunning("UltimateBackup");
            if(!Globals.UltimateBackupDep) { Game.DisplayNotification("Officer Status Plugin is optimised for use with UltimateBackup, It is highly advised to be installed!"); }
            Globals.StopThePedDep = IsLSPDFRPluginRunning("StopThePed");
            if (!Globals.UltimateBackupDep) { Game.DisplayNotification("Officer Status Plugin is optimised for use with StopThePed, It is highly advised to be installed!"); }
            Globals.VocalDispatchDep = IsLSPDFRPluginRunning("VocalDispatch");
            if (!Globals.UltimateBackupDep) { Game.DisplayNotification("Officer Status Plugin is optimised for use with VocalDispatch, It is highly advised to be installed!"); }
        }

        internal static void GetIni()
        {
            KeysConverter kc = new KeysConverter();

            InitializationFile ini = new InitializationFile("Plugins/lspdfr/Officer_Status_Plugin.ini");
            ini.Create();

            string menuKey = ini.ReadString("KeyBindings", "menuKey", "F7");
            Globals.rank = ini.ReadString("Officer", "rank", "CPT");
            Globals.firstName = ini.ReadString("Officer", "firstName", "Officer");
            Globals.lastName = ini.ReadString("Officer", "lastName", "Pope");
            Globals.unitNum = ini.ReadString("Officer", "unitNumber", "5H65");

            try
            {
                Globals.firstName = Globals.firstName.Substring(0, 1);
                Globals.Unit = Globals.rank + " " + Globals.firstName + "." + Globals.lastName + " " + Globals.unitNum;
                Globals.menuKey = (Keys)kc.ConvertFromString(menuKey);
            }
            catch
            {
                Globals.menuKey = Keys.F7;
                Game.DisplayNotification("~r~Officer Status Plugin: ~w~There was an error reading the .ini file. Setting defaults...");
            }
        }
    }
}
