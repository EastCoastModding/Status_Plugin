using System;
using System.Windows.Forms;
using System.Reflection;
using LSPD_First_Response.Mod.API;
using Rage;

namespace Officer_Status_Plugin
{
    class Utilities
    {
        public static bool IsLSPDFRPluginRunning(string Plugin, Version minversion = null)
        {
            foreach (Assembly assembly in Functions.GetAllUserPlugins())
            {
                AssemblyName an = assembly.GetName();
                if (an.Name.ToLower() == Plugin.ToLower())
                {
                    if (minversion == null || an.Version.CompareTo(minversion) >= 0)
                        return true;
                }
            }
            return false;
        }
        public static void GetIni()
        {
            KeysConverter kc = new KeysConverter();

            InitializationFile ini = new InitializationFile("Plugins/lspdfr/Officer_Status_Plugin.ini");
            ini.Create();

            string menuKey = ini.ReadString("KeyBindings", "menuKey", "F7");
            
            try
            {
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
