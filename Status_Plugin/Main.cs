using LSPD_First_Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using LSPD_First_Response.Engine.Scripting.Entities;
using Rage;
using Rage.Native;
using RAGENativeUI;
using RAGENativeUI.Elements;
using VocalDispatch;
using System.Windows.Forms;

namespace Status_Plugin
{
    public class Main : Plugin
    {

        public Main() { }

        //Start of Response Functions
        public bool ShowMe107()
        {
            try
            {
                Functions.SetPlayerAvailableForCalls(false);
                Game.DisplayNotification("Showing 10-7 (Not Available for calls)");
                Functions.PlayScannerAudio("10_4_COPY_1");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ShowMe108()
        {
            try
            {
                Functions.SetPlayerAvailableForCalls(true);
                Game.DisplayNotification("Showing you 10-8 (Available for calls)");
                Functions.PlayScannerAudio("10_4_COPY_1");
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool ShowMe1058()
        {
            try
            {
                Functions.SetPlayerAvailableForCalls(false);
                Game.DisplayNotification("Showing 10-58 (Direct Traffic Stop)");
                Functions.PlayScannerAudio("10_4_COPY_1");
                Functions.PlayScannerAudio("IS");
                Functions.PlayScannerAudio("BACKUP_REQUIRED");

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool ShowMe1019()
        {
            Functions.SetPlayerAvailableForCalls(false);
            Game.DisplayNotification("Showing 10-19 Station (Returning to Station)");
            return true;
        }
        //End of Response Functions

        //Start of object Init
        VocalDispatchHelper VDShowMe107 = new VocalDispatchHelper();
        VocalDispatchHelper VDShowMe108 = new VocalDispatchHelper();
        VocalDispatchHelper VDShowMe1058 = new VocalDispatchHelper();
        VocalDispatchHelper VDShowMe1019 = new VocalDispatchHelper();
        //End of object Init

        //Start of Plugin Sequences
        public override void Initialize()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Utilities.ResolveAssemblyEventHandler);

            Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;

            if (Utilities.IsLSPDFRPluginRunning("VocalDispatch", new System.Version(1, 5, 0, 0)) == true)
            {
                try
                {
                    VDShowMe107.SetupVocalDispatchAPI("StatusPlugin.ShowMe107", new Utilities.VocalDispatchEventDelegate(ShowMe107));
                    VDShowMe108.SetupVocalDispatchAPI("StatusPlugin.ShowMe108", new Utilities.VocalDispatchEventDelegate(ShowMe108));
                    VDShowMe1058.SetupVocalDispatchAPI("StatusPlugin.ShowMe1058", new Utilities.VocalDispatchEventDelegate(ShowMe1058));
                    VDShowMe1019.SetupVocalDispatchAPI("StatusPlugin.ShowMe1019", new Utilities.VocalDispatchEventDelegate(ShowMe1019));
                    Game.LogTrivial("Status Plugin " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " has been Initialized.");
                }
                catch (Exception e)
                {
                    Game.LogTrivial("Status Plugin " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " has failed to initialize. Due to: " + e.ToString());
                    Game.DisplayNotification("Status Plugin " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " has failed to initialize.");
                    Rage.Game.Console.Print("Error: " + e.ToString());
                }
            }
        }

        private static void OnOnDutyStateChangedHandler(bool OnDuty)
        {
            if (OnDuty)
            {
                Game.DisplayNotification("Status Plugin v0.1 has loaded successfully, thank you for downloading!");
            }
        }

        public override void Finally()
        {
            VDShowMe107.ReleaseVocalDispatchAPI();
            VDShowMe108.ReleaseVocalDispatchAPI();
            VDShowMe1058.ReleaseVocalDispatchAPI();
            VDShowMe1019.ReleaseVocalDispatchAPI();
            Game.LogTrivial("Status Plugin has cleaned up.");
        }
        //End of Plugin Sequences
    }
}
