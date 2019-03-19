using System;
using LSPD_First_Response.Mod.API;
using Rage;

namespace Status_Plugin
{
    public class Main : Plugin
    {

        public Main() { }

        public override void Initialize()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Utilities.ResolveAssemblyEventHandler);

            Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;

            Game.LogTrivial("Status Plugin " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " has been Initialized.");
        }

        private static void OnOnDutyStateChangedHandler(bool OnDuty)
        {
            if (OnDuty)
            {
                Game.DisplayNotification("Status Plugin v1.0 has loaded successfully, thank you for downloading!");
            }
        }

        public override void Finally()
        {
            Game.LogTrivial("Status Plugin has cleaned up.");
        }
    }
}
