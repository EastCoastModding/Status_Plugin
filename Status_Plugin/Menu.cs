using System;
using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using System.Windows.Forms;

namespace Officer_Status_Plugin
{
    public class Menu
    {
        private static UIMenuItem menuGeneralItem;
        private static UIMenuItem menuServiceItem;
        private static UIMenuItem menuBackupItem;

        private static UIMenuItem menu10_5Item;
        private static UIMenuItem menu10_6Item;
        private static UIMenuItem menu10_7Item;
        private static UIMenuItem menu10_8Item;
        private static UIMenuItem menu10_12Item;
        private static UIMenuItem menu10_19Item;
        private static UIMenuItem menu10_23Item;
        private static UIMenuItem menu10_41Item;
        private static UIMenuItem menu10_42Item;
        private static UIMenuItem menu10_51Item;
        private static UIMenuItem menuAffirmativeItem;
        private static UIMenuItem menuNegativeItem;

        private static GameFiber menuProcessFiber;
        private static UIMenu mainMenu;
        private static UIMenu serviceMenu;
        private static UIMenu generalMenu;
        private static UIMenu backupMenu;
        private static MenuPool _MenuPool;

        public static void Main()
        {
            menuProcessFiber = new GameFiber(MenuProcess);
            _MenuPool = new MenuPool();
            mainMenu = new UIMenu("~r~Officer Status Menu", "By " + Globals.author);
            serviceMenu = new UIMenu("~r~Service Status Menu", "By " + Globals.author);
            generalMenu = new UIMenu("~r~General Status Menu", "By " + Globals.author);
            backupMenu = new UIMenu("~r~Backup Status Menu", "By " + Globals.author);

            _MenuPool.Add(mainMenu);
            _MenuPool.Add(serviceMenu);
            _MenuPool.Add(generalMenu);

            serviceMenu.AddItem(menu10_5Item = new UIMenuItem(">>10-5", "Break"));
            serviceMenu.AddItem(menu10_6Item = new UIMenuItem(">>10-6", "Busy"));
            serviceMenu.AddItem(menu10_7Item = new UIMenuItem(">>10-7", "Out of Service"));
            serviceMenu.AddItem(menu10_8Item = new UIMenuItem(">>10-8", "Available for Calls"));
            serviceMenu.AddItem(menu10_41Item = new UIMenuItem(">>10-41", "Beginning Tour of Duty"));
            serviceMenu.AddItem(menu10_42Item = new UIMenuItem(">>10-42", "Ending Tour of Duty"));

            generalMenu.AddItem(menu10_12Item = new UIMenuItem(">>10-12", "Normal Traffic Stop"));
            generalMenu.AddItem(menu10_19Item = new UIMenuItem(">>10-19", "Returning to Station"));
            generalMenu.AddItem(menu10_23Item = new UIMenuItem(">>10-23", "Arrived on Scene"));
            generalMenu.AddItem(menuAffirmativeItem = new UIMenuItem(">>Affirmative"));
            generalMenu.AddItem(menuNegativeItem = new UIMenuItem(">>Negative"));

            backupMenu.AddItem(menu10_51Item = new UIMenuItem(">>10_51", "Request a Tow Truck"));

            mainMenu.AddItem(menuGeneralItem = new UIMenuItem("General Statuses"));
            mainMenu.BindMenuToItem(generalMenu, menuGeneralItem);
            generalMenu.ParentMenu = mainMenu;
            mainMenu.AddItem(menuServiceItem = new UIMenuItem("Service Statuses"));
            mainMenu.BindMenuToItem(serviceMenu, menuServiceItem);
            serviceMenu.ParentMenu = mainMenu;
            mainMenu.AddItem(menuBackupItem = new UIMenuItem("Backup Statuses"));
            mainMenu.BindMenuToItem(backupMenu, menuBackupItem);
            backupMenu.ParentMenu = mainMenu;

            mainMenu.RefreshIndex();
            serviceMenu.RefreshIndex();
            generalMenu.RefreshIndex();
            backupMenu.RefreshIndex();

            mainMenu.OnItemSelect += OnItemSelect;
            generalMenu.OnItemSelect += OnItemSelect;
            serviceMenu.OnItemSelect += OnItemSelect;
            backupMenu.OnItemSelect += OnItemSelect;

            mainMenu.AllowCameraMovement = true;
            mainMenu.MouseControlsEnabled = false;
            serviceMenu.AllowCameraMovement = true;
            serviceMenu.MouseControlsEnabled = false;
            generalMenu.AllowCameraMovement = true;
            generalMenu.MouseControlsEnabled = false;
            backupMenu.AllowCameraMovement = true;
            backupMenu.MouseControlsEnabled = false;

            menuProcessFiber.Start();
            Game.Console.Print(Globals.PluginName + ": Menus Initialised");
        }

        private static void OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            Statuses statuses = new Statuses();
            if(sender == generalMenu)
            {
                if (selectedItem == menu10_12Item) { statuses.ShowMe10_12(); }
                else if (selectedItem == menu10_19Item) { statuses.ShowMe10_19(); }
                else if (selectedItem == menu10_23Item) { statuses.ShowMe10_23(); }
                else if (selectedItem == menuAffirmativeItem) { statuses.Affirmative(); }
                else if (selectedItem == menuNegativeItem) { statuses.Negative(); }
            }
            if(sender == serviceMenu)
            {
                if (selectedItem == menu10_5Item) { statuses.ShowMe10_5();  }
                else if (selectedItem == menu10_6Item) { statuses.ShowMe10_6(); }
                else if (selectedItem == menu10_7Item) { statuses.ShowMe10_7(); }
                else if (selectedItem == menu10_8Item) { statuses.ShowMe10_8(); }
                else if (selectedItem == menu10_41Item) { statuses.ShowMe10_41(); }
                else if (selectedItem == menu10_42Item) { statuses.ShowMe10_42(); }
            }
            if(sender == backupMenu)
            {
                if(selectedItem == menu10_51Item)
                {
                    statuses.Requesting10_51();
                }
            }
        }

        private static void MenuProcess()
        {
            while(true)
            {
                GameFiber.Yield();
                if (Game.IsKeyDown(Globals.menuKey))
                {
                    mainMenu.Visible = !mainMenu.Visible;

                }
                _MenuPool.ProcessMenus();
            }
        }

        public static void Stop()
        {
            _MenuPool.CloseAllMenus();
            menuProcessFiber.Abort();
        }
    }
}