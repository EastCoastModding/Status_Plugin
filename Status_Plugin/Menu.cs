using System;
using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using System.Windows.Forms;
using System.Collections.Generic;

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
        private static UIMenuListItem menu10_12List;
        private static object[] List10_12 = new object[] { "10-12 Occupied 1x", "10-12 Occupied 2x", "10-12 Occupied 3x", "10-12 Occupied 4x" };
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
            _MenuPool.Add(backupMenu);

            serviceMenu.AddItem(menu10_5Item = new UIMenuItem(">>10-5", "~g~Break"));
            serviceMenu.AddItem(menu10_6Item = new UIMenuItem(">>10-6", "~g~Busy"));
            serviceMenu.AddItem(menu10_7Item = new UIMenuItem(">>10-7", "~g~Out of Service"));
            serviceMenu.AddItem(menu10_8Item = new UIMenuItem(">>10-8", "~g~Available for Calls"));
            serviceMenu.AddItem(menu10_41Item = new UIMenuItem(">>10-41", "~g~Beginning Tour of Duty"));
            serviceMenu.AddItem(menu10_42Item = new UIMenuItem(">>10-42", "~g~Ending Tour of Duty"));

            generalMenu.AddItem(menu10_12List = new UIMenuListItem("10-12","~g~Traffic Stop", List10_12));
            generalMenu.AddItem(menu10_19Item = new UIMenuItem(">>10-19", "~g~Returning to Station"));
            generalMenu.AddItem(menu10_23Item = new UIMenuItem(">>10-23", "~g~Arrived on Scene"));
            generalMenu.AddItem(menuAffirmativeItem = new UIMenuItem(">>Affirmative"));
            generalMenu.AddItem(menuNegativeItem = new UIMenuItem(">>Negative"));

            backupMenu.AddItem(menu10_51Item = new UIMenuItem(">>10-51", "~g~Request a Tow Truck"));

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
            TS10_12Funcs ts10_12Funcs = new TS10_12Funcs();
            if(sender == generalMenu)
            {
                if (selectedItem == menu10_19Item) { statuses.ShowMe10_19(); }
                else if (selectedItem == menu10_23Item) { statuses.ShowMe10_23(); }
                else if (selectedItem == menuAffirmativeItem) { statuses.Affirmative(); }
                else if (selectedItem == menuNegativeItem) { statuses.Negative(); }
                else if (selectedItem == menu10_12List)
                {
                    string selectedListItem = menu10_12List.SelectedItem.ToString();
                    if (selectedListItem == "10-12 Occupied 1x")
                    {
                        ts10_12Funcs.ShowMe10_12O1();
                    }
                    if (selectedListItem == "10-12 Occupied 2x")
                    {
                        ts10_12Funcs.ShowMe10_12O2();
                    }
                    if (selectedListItem == "10-12 Occupied 3x")
                    {
                        ts10_12Funcs.ShowMe10_12O3();
                    }
                    if (selectedListItem == "10-12 Occupied 4x")
                    {
                        ts10_12Funcs.ShowMe10_12O4();
                    }
                }
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