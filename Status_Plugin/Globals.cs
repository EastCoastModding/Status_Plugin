using System.Reflection;
using System.Windows.Forms;
[assembly: AssemblyFileVersion("1.0.2.0"), AssemblyVersion("1.0.2.0")]

namespace Officer_Status_Plugin
{
    static class Globals
    {
        public readonly static string PluginName = "Officer Status Plugin";
        public readonly static string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public readonly static string author = "OfficerPope";
        public static bool IsTSBackupRequired = false;
        public static Keys menuKey;
    }
}
