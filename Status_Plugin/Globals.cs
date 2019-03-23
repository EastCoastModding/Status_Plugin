using System.Reflection;
[assembly: AssemblyFileVersion("1.0.1.0"), AssemblyVersion("1.0.1.0")]
namespace Status_Plugin
{
    static class Globals
    {
        public readonly static string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public readonly static string author = "OfficerPope";
        public static bool IsTSBackupRequired = false;
    }
}
