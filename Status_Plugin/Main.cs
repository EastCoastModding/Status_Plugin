using System;
using LSPD_First_Response.Mod.API;
using Rage;
using VocalDispatch;
using Status_Plugin.Statuses;
using RAGENativeUI.Elements;
using RAGENativeUI;
using System.Windows.Forms;

namespace Status_Plugin
{
    public class Main : Plugin
    {
        //Variables
        readonly string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static bool IsTSBackupRequired = false;
        //End of Variables

        //Instances
        UIMenu statusMenu = new UIMenu("~u~Status Plugin", "~r~By OfficerPope");
        public static MenuPool statusMenuPool = new MenuPool();

        ShowMe10_7 showMe10_7 = new ShowMe10_7();
        ShowMe10_8 showMe10_8 = new ShowMe10_8();
        ShowMe10_19 showMe10_19 = new ShowMe10_19();
        ShowMe10_58 showMe10_58 = new ShowMe10_58();
        Affirmative affirmative = new Affirmative();
        Negative negative = new Negative();
        //End of Instances

        //Menu Functions
        private void MenuRegister()
        {
            statusMenu.AddItem(new UIMenuItem("10-7", "Unavailable for calls"));
            statusMenu.AddItem(new UIMenuItem("10-8", "Available for calls"));
            statusMenu.AddItem(new UIMenuItem("10-19", "Returning to station"));
            statusMenu.AddItem(new UIMenuItem("10-58", "Normal traffic stop"));
            statusMenu.AddItem(new UIMenuItem("Affirmative"));
            statusMenu.AddItem(new UIMenuItem("Negative"));
            statusMenu.RefreshIndex();

            statusMenu.OnItemSelect += StatusMenu_OnItemSelect;
        }

        private void StatusMenu_OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if(selectedItem.Text == "10-7")
            {
                showMe10_7.ShowMe10_7Func();
            }
            if(selectedItem.Text == "10-8")
            {
                showMe10_8.ShowMe10_8Func();
            }
            if (selectedItem.Text == "10-19")
            {
                showMe10_19.ShowMe10_19Func();
            }
            if (selectedItem.Text == "10-58")
            {
                showMe10_58.ShowMe10_58Func();
            }
            if (selectedItem.Text == "Affirmative")
            {
                affirmative.AffirmativeFunc();
            }
            if (selectedItem.Text == "Negative")
            {
                negative.NegativeFunc();
            }
        }

        private void Process(object sender, GraphicsEventArgs e)
        {
            if (Game.IsKeyDown(Keys.Decimal))
            {
                statusMenu.Visible = !statusMenu.Visible;
            }
            statusMenuPool.ProcessMenus();
        }
        //End of Menu Functions

        //Vocal Dispatch Functions
        private void VDRegister()
        {
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_7", showMe10_7.ShowMe10_7Func);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_8", showMe10_8.ShowMe10_8Func);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_19", showMe10_19.ShowMe10_19Func);
            APIv1.RegisterEventHandler("StatusPlugin.ShowMe10_58", showMe10_58.ShowMe10_58Func);
            APIv1.RegisterEventHandler("StatusPlugin.Affirmative", affirmative.AffirmativeFunc);
            APIv1.RegisterEventHandler("StatusPlugin.Negative", negative.NegativeFunc);

            Game.Console.Print("Status Plugin: Registered all Vocal Dispatch Events");
        }
        //End of Vocal Dispatch Functions

        //Plugin Base Functions
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
                    MenuRegister();

                    VDRegister();

                    Game.DisplayNotification("Status Plugin " + version + " has loaded successfully, thank you for downloading!");
                }
                catch (Exception e)
                {
                    Game.DisplayNotification("Status Plugin " + version + " has failed to load successfully!!");
                }
            }
        }

        public override void Finally()
        {
            Game.LogTrivial("Status Plugin has cleaned up.");
        }
        //End of Plugin Base Functions
    }
}
