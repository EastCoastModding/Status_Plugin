using System;
using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Officer_Status_Plugin
{
    internal class Menu
    {
        private static UIMenuItem menuGeneralItem;
        private static UIMenuItem menuServiceItem;
        private static UIMenuItem menuBackupItem;

        private static UIMenuItem menu10_5Item;
        private static UIMenuItem menu10_6Item;
        private static UIMenuItem menu10_7Item;
        private static UIMenuItem menu10_8Item;
        private static UIMenuListItem menu10_11List;
        private static object[] List10_11 = new object[] { "Occupied x1", "Occupied x2", "Occupied x3", "Occupied x4" };
        private static UIMenuItem menu10_15Item;
        private static UIMenuItem menu10_19Item;
        private static UIMenuItem menu10_23Item;
        private static UIMenuListItem menu10_32List;
        private static object[] List10_32 = new object[] { "Code 2", "Code 3", "Female"};
        private static UIMenuItem menu10_41Item;
        private static UIMenuItem menu10_42Item;
        private static UIMenuItem menu10_51Item;
        private static UIMenuItem menu10_52Item;
        private static UIMenuItem menu10_53Item;
        private static UIMenuItem menu10_99Item;
        private static UIMenuItem menuAffirmativeItem;
        private static UIMenuItem menuNegativeItem;
        private static UIMenuItem menuCode5Item;

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
            mainMenu = new UIMenu("Officer Status Menu", "" + Globals.Unit);
            mainMenu.SetMenuWidthOffset(10);
            serviceMenu = new UIMenu("Service Status Menu", "" + Globals.Unit);
            serviceMenu.SetMenuWidthOffset(10);
            generalMenu = new UIMenu("General Status Menu", "" + Globals.Unit);
            generalMenu.SetMenuWidthOffset(10);
            backupMenu = new UIMenu("Backup Status Menu", "" + Globals.Unit);
            backupMenu.SetMenuWidthOffset(10);

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

            generalMenu.AddItem(menu10_11List = new UIMenuListItem(">>10-11","~g~Traffic Stop", List10_11));
            generalMenu.AddItem(menu10_15Item = new UIMenuItem(">>10-15", "~g~Suspect in Custody, Returning to Station"));
            generalMenu.AddItem(menu10_19Item = new UIMenuItem(">>10-19", "~g~Returning to Station"));
            generalMenu.AddItem(menu10_23Item = new UIMenuItem(">>10-23", "~g~Arrived on Scene"));
            generalMenu.AddItem(menuCode5Item = new UIMenuItem(">>Code 5", "~g~Felony Stop"));
            generalMenu.AddItem(menuAffirmativeItem = new UIMenuItem(">>Affirmative"));
            generalMenu.AddItem(menuNegativeItem = new UIMenuItem(">>Negative"));

            backupMenu.AddItem(menu10_32List = new UIMenuListItem(">>10-32", "~g~General Backup", List10_32));
            backupMenu.AddItem(menu10_51Item = new UIMenuItem(">>10-51", "~g~Request a Tow Truck"));
            backupMenu.AddItem(menu10_52Item = new UIMenuItem(">>10-52", "~g~Request an EMS"));
            backupMenu.AddItem(menu10_53Item = new UIMenuItem(">>10-53", "~g~Request Fire Department"));

            mainMenu.AddItem(menuGeneralItem = new UIMenuItem("General Statuses"));
            mainMenu.BindMenuToItem(generalMenu, menuGeneralItem);
            generalMenu.ParentMenu = mainMenu;
            mainMenu.AddItem(menuServiceItem = new UIMenuItem("Service Statuses"));
            mainMenu.BindMenuToItem(serviceMenu, menuServiceItem);
            serviceMenu.ParentMenu = mainMenu;
            mainMenu.AddItem(menuBackupItem = new UIMenuItem("Backup Statuses"));
            mainMenu.BindMenuToItem(backupMenu, menuBackupItem);
            backupMenu.ParentMenu = mainMenu;
            mainMenu.AddItem(menu10_99Item = new UIMenuItem("Panic"));
            menu10_99Item.BackColor = Color.Red;

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
            TS10_11Funcs ts10_11Funcs = new TS10_11Funcs();
            if(sender == generalMenu && selectedItem == menu10_11List) { } else { _MenuPool.CloseAllMenus(); }
            if(sender == mainMenu)
            {
                if(selectedItem == menu10_99Item)
                {
                    statuses.ShowMe10_99();
                }
            }
            if(sender == generalMenu)
            {
                if (selectedItem == menu10_11List)
                {
                    string selectedListItem = menu10_11List.SelectedItem.ToString();
                    if (selectedListItem == "Occupied x1")
                    {
                        ts10_11Funcs.ShowMe10_11O1();
                    }
                    if (selectedListItem == "Occupied x2")
                    {
                        ts10_11Funcs.ShowMe10_11O2();
                    }
                    if (selectedListItem == "Occupied x3")
                    {
                        ts10_11Funcs.ShowMe10_11O3();
                    }
                    if (selectedListItem == "Occupied x4")
                    {
                        ts10_11Funcs.ShowMe10_11O4();
                    }
                }
                else if (selectedItem == menu10_15Item) { statuses.ShowMe10_15(); }
                else if (selectedItem == menu10_19Item) { statuses.ShowMe10_19(); }
                else if (selectedItem == menu10_23Item) { statuses.ShowMe10_23(); }
                else if (selectedItem == menuCode5Item) { statuses.ShowMeCode5(); }
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
                if (selectedItem == menu10_32List)
                {
                    string selectedListItem = menu10_32List.SelectedItem.ToString();
                    if (selectedListItem == "Code 2")
                    {
                        statuses.Requesting10_32C2();
                    }
                    else if (selectedListItem == "Code 3")
                    {
                        statuses.Requesting10_32C3();
                    }
                    else if (selectedListItem == "Female")
                    {
                        statuses.Requesting10_32F();
                    }
                }
                else if(selectedItem == menu10_51Item)
                {
                    statuses.Requesting10_51();
                }
                else if(selectedItem == menu10_52Item)
                {
                    statuses.Requesting10_52();
                }
                else if(selectedItem == menu10_53Item)
                {
                    statuses.Requesting10_53();
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