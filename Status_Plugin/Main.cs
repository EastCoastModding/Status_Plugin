using System;
using LSPD_First_Response.Mod.API;
using Rage;
using VocalDispatch;
using Status_Plugin.Statuses;
using RAGENativeUI.Elements;
using RAGENativeUI;
using System.Windows.Forms;
using System.Drawing;

namespace Status_Plugin
{
    public class Main : Plugin
    {
        //Variables
        private static UIMenuItem menu10_7Item;
        private static UIMenuItem menu10_8Item;
        private static UIMenuItem menu10_19Item;
        private static UIMenuItem menu10_58Item;
        private static UIMenuItem menuAffirmativeItem;
        private static UIMenuItem menuNegativeItem;
        private static UIMenu mainMenu;
        private static MenuPool menuPool;
        private static GameFiber menuFiber;

        readonly string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static bool IsTSBackupRequired = false;
        //End of Variables

        //Instances
        private static ShowMe10_7 showMe10_7 = new ShowMe10_7();
        private static ShowMe10_8 showMe10_8 = new ShowMe10_8();
        private static ShowMe10_19 showMe10_19 = new ShowMe10_19();
        private static ShowMe10_58 showMe10_58 = new ShowMe10_58();
        private static Affirmative affirmative = new Affirmative();
        private static Negative negative = new Negative();
        //End of Instances

        //Menu Functions
        public static void MenuRegister()
        {
            menuPool = new MenuPool();
            mainMenu = new UIMenu("~u~Status Plugin", "~r~By OfficerPope");
            menuPool.Add(mainMenu);

            mainMenu.AddItem(menu10_7Item = new UIMenuItem("10-7", "Unavailable for Calls"));
            mainMenu.AddItem(menu10_8Item = new UIMenuItem("10-8", "Available for Calls"));
            mainMenu.AddItem(menu10_19Item = new UIMenuItem("10-19", "Returning to Station"));
            mainMenu.AddItem(menu10_58Item = new UIMenuItem("10-58", "Normal Traffic Stop"));
            mainMenu.AddItem(menuAffirmativeItem = new UIMenuItem("Affirmative"));
            mainMenu.AddItem(menuNegativeItem = new UIMenuItem("Negative"));

            mainMenu.RefreshIndex();
            mainMenu.OnItemSelect += OnItemSelect;
            mainMenu.MouseControlsEnabled = false;
            mainMenu.AllowCameraMovement = true;
            menuFiber = new GameFiber(Process, "Menu_Fiber");
            menuFiber.Start();
        }

        public static void OnItemSelect(UIMenu sender,UIMenuItem selectedItem, int index)
        {
            if (sender == mainMenu)
            {
                if (selectedItem == menu10_7Item)
                {
                    showMe10_7.ShowMe10_7Func();
                }
            }
        }

        public static void Process()
        {
            if (Game.IsKeyDown(Keys.F7))
            {
                mainMenu.Visible = !mainMenu.Visible;
            }
            menuPool.ProcessMenus();
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
        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += Functions_OnOnDutyStateChanged;

            Game.LogTrivial("Status Plugin " + version + " has been Initialized.");
        }

        private void Functions_OnOnDutyStateChanged(bool onDuty)
        {
            if (onDuty)
            {
                VDRegister();

                MenuRegister();

                Game.DisplayNotification("Status Plugin " + version + " has loaded successfully, thank you for downloading!");
            }
        }

        public override void Finally()
        {
            Game.LogTrivial("Status Plugin has cleaned up.");
        }
        //End of Plugin Base Functions
    }
}
