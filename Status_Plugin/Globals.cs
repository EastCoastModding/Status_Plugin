﻿using System.Reflection;
using System.Windows.Forms;
[assembly: AssemblyFileVersion("1.0.3.6"), AssemblyVersion("1.0.3.6")]

namespace Officer_Status_Plugin
{
    static class Globals
    {
        public static Keys menuKey;
        public static string rank;
        public static string firstName;
        public static string lastName;
        public static string unitNum;
        public static string Unit;

        public readonly static string PluginName = "Officer Status Plugin";
        public readonly static string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static bool IsTSBackupRequired = false;
    }
}
