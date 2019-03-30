using System;
using LSPD_First_Response.Mod.API;
using Rage;

namespace OPCallouts
{
    public class Main : Plugin
    {
        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;
            Game.LogTrivial("OPCallouts " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " has been Initialized");
            Game.LogTrivial("Go on duty to fully load OPCallouts");
        }

        private void OnOnDutyStateChangedHandler(bool onDuty)
        {
            if (onDuty)
            {
                RegisterCallouts();
            }
        }

        public override void Finally()
        {
            Game.LogTrivial("OPCallouts has cleaned up");
        }

        private static void RegisterCallouts()
        {
            Functions.RegisterCallout(typeof(Callouts.ArrestWarrantStabCity));
        }
    }
}
