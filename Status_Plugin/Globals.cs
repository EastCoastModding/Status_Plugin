namespace Status_Plugin
{
    static class Globals
    {
        public readonly static string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public readonly static string author = "OfficerPope";
        public static bool IsTSBackupRequired = false;
    }
}
