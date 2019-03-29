using System.Reflection;
using System.Windows.Forms;
[assembly: AssemblyFileVersion("1.0.4.0"), AssemblyVersion("1.0.4.0")]

namespace Officer_Status_Plugin
{
    internal static class Globals
    {
        internal static Keys menuKey;
        internal static string rank;
        internal static string firstName;
        internal static string lastName;
        internal static string unitNum;
        internal static string Unit;
        internal static string State = "NorthCarolina";

        internal static readonly string PluginName = "Officer Status Plugin";
        internal static readonly string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        internal static bool IsTSBackupRequired = false;
        internal static bool signalling100 = false;
    }
}
