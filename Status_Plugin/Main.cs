using System;
using LSPD_First_Response.Mod.API;
using Rage;
using VocalDispatch;
using Status_Plugin.Statuses;

namespace Status_Plugin
{
    public class Main : Plugin
    {
        string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static bool IsTSBackupRequired = false;

        ShowMe10_7 showMe10_7 = new ShowMe10_7();
        ShowMe10_8 showMe10_8 = new ShowMe10_8();

        public Main() { }

        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += Functions_OnOnDutyStateChanged;

            Game.LogTrivial("Status Plugin " + version + " has been Initialized.");
        }

        private void Functions_OnOnDutyStateChanged(bool onDuty)
        {
            if (onDuty)
            {
                try
                {
                    APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_7", showMe10_7.ShowMe10_7Func);
                    APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_8", showMe10_8.ShowMe10_8Func);

                    Game.DisplayNotification("Status Plugin " + version + " has loaded successfully, thank you for downloading!");
                }
                catch(Exception e)
                {
                    Game.DisplayNotification("Status Plugin " + version + " has failed to load successfully!!");
                }
            }
        }

        public override void Finally()
        {
            Game.LogTrivial("Status Plugin has cleaned up.");
        }
    }
}
